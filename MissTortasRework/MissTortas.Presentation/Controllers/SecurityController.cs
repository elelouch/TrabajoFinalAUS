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
using MissTortas.Data.Entity.Security.Permissions;

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
                Username = user.UserName!,
                Roles = [.. user.UserRoles.Select(ur => ur.Role.Name ?? "")]
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
            if(result == null)
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


        [Authorize(Policy = "Claims.ViewAll")]
        [HttpGet("permission")]
        public async Task<IEnumerable<Permission>> GetAllPermissions()
        {
            return await securityService.GetAllPermissionAsync();
        }

        [Authorize(Policy = "Roles.ViewAll")]
        [HttpGet("role")]
        public async Task<IEnumerable<string>> GetAllRoles()
        {
            return await securityService.GetAllRolesAsync();
        }

        [Authorize(Policy = "Roles.AssignClaim")]
        [HttpPost("role/assign/permission")]
        public async Task<ActionResult> PostAssignPermissionToRole(AssignPermissionToRole assignPermissionsDTO)
        {
            await validator.AssignPermissionToRoleValidator().ValidateAndThrowAsync(assignPermissionsDTO);
            var serviceDto = new AssignPermissionsToRoleDTO
            {
                RoleId = assignPermissionsDTO.RoleId,
                Permissions = assignPermissionsDTO.Permissions
            };
            await securityService.AssignPermissionsAsync(serviceDto);
            return Ok();
        }

        [HttpPut("user/modification")]
        public async Task<ActionResult> PostUserModification(UserModification userModificationDTO)
        {
            await validator.UserModificationValidator().ValidateAndThrowAsync(userModificationDTO);
            var serviceDto = new UserModificationDTO
            {
                IsEnabled = userModificationDTO.Enabled,
                Username = userModificationDTO.Username,
                Email = userModificationDTO.Email,
                Roles = userModificationDTO.Roles
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
