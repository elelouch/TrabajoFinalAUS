using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Interface;
using MissTortas.Presentation.DTO.Security;

namespace MissTortas.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController(ISecurityService securityService) : Controller
    {
        [HttpPost("login")]
        public async Task<ActionResult<UserLogin>> LoginUser(
                LoginRequest request
           )
        {
            var loginDto = new LoginUserDTO
            {
                Username = request.Email,
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
            var userLogin = new UserLogin
            {
                Id = result.Id,
                Username = result.Username,
                AccessToken = result.AccessToken
            };
            return Ok(userLogin);
        }

        [HttpPost("signup")]
        public async Task<ActionResult<UserLogin>> SignUpUser(RegisterRequest request)
        {
            var serviceDto = new SignUpUserDTO
            {
                Username = request.Email,
                Password = request.Password
            };

            var result = await securityService.SignUpUserAsync(serviceDto);
            var ret = new SignUpUser
            {
                Username = result.Email,
                Result = result.IdentityResult!
            };
            return Ok(ret);
        }
    }
}
