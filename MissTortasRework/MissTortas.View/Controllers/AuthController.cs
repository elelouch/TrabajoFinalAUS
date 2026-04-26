using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Infrastructure.Security.Interface;
using MissTortas.Services.DTO.Security;
using MissTortas.Services.Interfaces;
using MissTortas.View.DTO.Error;
using MissTortas.View.DTO.Security;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AuthController(ISecurityService securityService, IUserService userServices) : ControllerBase
    {
        [HttpPost("signin")]
        public async Task<ActionResult> SignInUser(LoginRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var loginDto = new LoginUserDTO
            {
                Email = request.Email,
                Password = request.Password
            };
            var result = await securityService.SignInUserAsync(loginDto);

            if (result == null)
            {
                var errorDTO = new ErrorDTO
                {
                    Message = "User not found.",
                    Code = "USRNF1",
                };
                return NotFound(errorDTO);
            }
            if (!result.SignInResult.Succeeded)
            {
                return result.SignInResult switch
                {
                    { IsLockedOut: true } => Unauthorized(new ErrorDTO
                    {
                        Message = "User is locked out.",
                        Code = "USRLO1",
                        Details = null
                    }),

                    { IsNotAllowed: true } => Unauthorized(new ErrorDTO
                    {
                        Message = "User is not allowed to sign in.",
                        Code = "USRNO1",
                        Details = null
                    }),

                    { RequiresTwoFactor: true } => Unauthorized(new ErrorDTO
                    {
                        Message = "Two-factor authentication is required.",
                        Code = "USR2F1",
                        Details = new { requiresTwoFactor = true }
                    }),

                    _ => Unauthorized(new ErrorDTO
                    {
                        Message = "Invalid login attempt.",
                        Code = "USRINV1",
                        Details = null
                    })
                };
            }
            Response.Cookies.Append("X-Access-Token", result.AccessToken, new CookieOptions { HttpOnly = true, SameSite = SameSiteMode.Strict });
            Response.Cookies.Append("X-Username", result.Username, new CookieOptions { HttpOnly = true, SameSite = SameSiteMode.Strict });
            Response.Cookies.Append("X-Refresh-Token", Guid.NewGuid().ToString(), new CookieOptions { HttpOnly = true, SameSite = SameSiteMode.Strict });
            return NoContent();
        }

        [HttpPost("signup")]
        public async Task<ActionResult<UserLogin>> SignUpUser(RegisterRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var createUserDTO = new CreateUserDTO { };
            var userId = await userServices.CreateUserAsync(createUserDTO);
            var serviceDto = new SignUpUserDTO
            {
                UserId = userId,
                Username = request.Email,
                Password = request.Password
            };
            var result = await securityService.SignUpUserAsync(serviceDto);
            var identityResult = result.IdentityResult;
            if (!identityResult.Succeeded)
            {
                var errors = string.Join(",", identityResult.Errors.Select(err => err.Description));
                var errorDTO = new ErrorDTO
                {
                    Message = errors,
                    Code = "AUTHSU1",
                };
                return Conflict(errorDTO);
            }
            return Created();
        }
    }
}
