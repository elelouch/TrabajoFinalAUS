using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Infrastructure.Entity;
using MissTortas.Infrastructure.Security.Interface;
using MissTortas.Services.DTO.Security;
using MissTortas.Services.Interfaces;
using MissTortas.View.DTO.Error;
using MissTortas.View.DTO.Security;

namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(ISecurityService securityService, IUserService userServices, IValidator<MissTortasRegisterRequest> registerRequestValidator) : ControllerBase
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
            Response.Cookies.Append("X-Refresh-Token", result.RefreshToken, new CookieOptions { HttpOnly = true, SameSite = SameSiteMode.Strict, Secure = true });
            return Ok(new { accessToken = result.AccessToken, refreshToken = result.RefreshToken });
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<ActionResult> SignUpUser(MissTortasRegisterRequest request)
        {
            await registerRequestValidator.ValidateAndThrowAsync(request);

            var createUserDTO = new CreateUserDTO
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
                Roles = [UserConstants.UserRoleName]
            };
            var userId = await userServices.CreateUserAsync(createUserDTO);
            var serviceDto = new SignUpUserDTO
            {
                UserId = userId,
                Username = request.Username,
                Email = request.Email,
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
            return Ok(new { result.UserId });
        }
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request)
        {
            if (string.IsNullOrEmpty(request.RefreshToken))
            {
                return BadRequest("Refresh token is required.");
            }

            try
            {
                var result = await securityService.RefreshTokenAsync(request.RefreshToken);
                if (result == null)
                {
                    return Unauthorized("Invalid or expired refresh token.");
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return Unauthorized("Invalid refresh token.");
            }
        }
        public class RefreshTokenRequest
        {
            public string RefreshToken { get; set; } = string.Empty;
        }
    }
}
