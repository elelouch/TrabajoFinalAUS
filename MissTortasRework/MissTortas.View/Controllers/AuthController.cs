using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Infrastructure.Security.Interface;
using MissTortas.Services.DTO.Security;
using MissTortas.Services.Interfaces;
using MissTortas.View.DTO.Error;
using MissTortas.View.DTO.Security;

namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(ISecurityService securityService, IUserService userServices) : ControllerBase
    {
        [HttpPost("signout")]
        public async Task<ActionResult> SignOutUser()
        {
            Response.Cookies.Append(
                "X-Access-Token",
                Guid.NewGuid().ToString().Replace("-", ""),
                new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Secure = true,
                    Expires = DateTimeOffset.UnixEpoch
                });
            Response.Cookies.Append(
                "X-Refresh-Token",
                Guid.NewGuid().ToString().Replace("-", ""),
                new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Secure = true,
                    Expires = DateTimeOffset.UnixEpoch
                });
            Response.Cookies.Append(
                ".AspNetCore.Identity.Application",
                Guid.NewGuid().ToString().Replace("-", ""),
                new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Secure = true,
                    Expires = DateTimeOffset.UnixEpoch
                });

            return Ok();
        }

        [AllowAnonymous]
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
                    }),

                    { IsNotAllowed: true } => Unauthorized(new ErrorDTO
                    {
                        Message = "User is not allowed to sign in.",
                        Code = "USRNO1",
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
                    })
                };
            }
            Response.Cookies.Append("X-Access-Token", result.AccessToken, new CookieOptions { HttpOnly = true, SameSite = SameSiteMode.Strict, Secure = true });
            // refresh token placeholder
            Response.Cookies.Append("X-Refresh-Token", Guid.NewGuid().ToString(), new CookieOptions { HttpOnly = true, SameSite = SameSiteMode.Strict, Secure = true });
            return Ok(new { accessToken = result.AccessToken });
        }

        [AllowAnonymous]
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
