using Microsoft.AspNetCore.Mvc;
using System.Collections;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using MissTortas.Services.Mapper;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Presentation.DTO.Security;
using MissTortas.Services.DTO.Security;
using MissTortas.Services;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Security.Requirements;
using MissTortas.Services.Security.Constants;
using MissTortas.Presentation.Validators.Security;
using System.Security.Claims;

namespace MissTortas.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SecurityController(
        ISecurityService securityService, 
        IAuthorizationService authorizationService,
        ISecurityDTOValidator validator
    ) : Controller
    {

        [Authorize(Policy = "Users.ViewAll")]
        [HttpGet("user")]
        public async Task<ActionResult<List<UserLogin>>> AllUser()
        {
            var allUsers = await securityService.GetAllUsersAsync();
            var allUserDTO = allUsers.Select(user => new UserLogin
            {
                Id = user.Id,
                Username = user.UserName!
            }).ToList();
            return Ok(allUserDTO);
        }

        [AllowAnonymous]
        [HttpPost("user/login")]
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


        [Authorize(Policy = "Claims.ViewAll")]
        [HttpGet("permission")]
        public async Task<IEnumerable<SimpleClaim>> GetAllPermissions()
        {
            return securityService.GetAllAvailableClaims().Select(cl => new SimpleClaim { ClaimType = cl.Type, ClaimValue = cl.Value}).ToList();
        }

        [Authorize(Policy = "Roles.AssignClaim")]
        [HttpPost("role/assign/permission")]
        public async Task<ActionResult> PostAssignPermissionToRole(AssignPermissionToRole assignPermissionsDTO)
        {
            var claims = assignPermissionsDTO.Claims.Select(c => new Claim(c.ClaimType, c.ClaimValue)).ToList();
            var serviceDto = new AssignClaimsToRoleDTO
            {
                RoleId = assignPermissionsDTO.RoleId,
                Claims = claims
            };
            await securityService.AssignClaimsAsync(serviceDto);
            return Ok();
        }

        [HttpPut("user/modification")]
        public async Task<ActionResult> PostUserModification(UserModification userModificationDTO)
        {
            await validator.UserModificationValidator().ValidateAndThrowAsync(userModificationDTO);
            var serviceDto = new UserModificationDTO
            {
                IsEnabled = userModificationDTO.IsEnabled,
                Username = userModificationDTO.Username,
                Email = userModificationDTO.Email,
                Role = userModificationDTO.Role
            };
            var updateUserRequirement = new UpdateUserRequirement();

            await authorizationService.AuthorizeAsync(User, userModificationDTO, updateUserRequirement);

            await securityService.ModifyUserAsync(serviceDto);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("user/register")]
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
