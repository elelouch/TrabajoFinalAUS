using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Infrastructure.Security.Interface;
using MissTortas.Services.DTO.Security;
using MissTortas.Services.Interfaces;
using MissTortas.View.DTO.Security;

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
                return NotFound("User not found.");
            }
            if (!result.SignInResult.Succeeded)
            {
                return result.SignInResult switch
                {
                    { IsLockedOut: true } => Unauthorized(new { Message = "User is locked out." }),
                    { IsNotAllowed: true } => Unauthorized(new { Message = "User is not allowed to sign in." }),
                    { RequiresTwoFactor: true } => Unauthorized(new { Message = "Two-factor authentication is required." }),
                    _ => Unauthorized(new { Message = "Invalid login attempt." })
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
                return BadRequest(new { Message = "Signup failed.", Errors = errors });
            }
            return Created();
        }
    }
}
