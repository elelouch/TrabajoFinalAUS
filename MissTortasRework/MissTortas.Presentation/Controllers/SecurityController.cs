using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Permissions;
using MissTortas.Presentation.DTO.Security;
using MissTortas.Presentation.Mappers;
using MissTortas.Presentation.Validators.Security;
using MissTortas.Services.DTO.Security;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Security.Requirements;

namespace MissTortas.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SecurityController(
        ISecurityService securityService,
        IAuthorizationService authorizationService,
        ISecurityDTOValidator validator,
        IUserMapper userMapper
    ) : Controller
    {

        [Authorize(Policy = PolicyName.ReadUsers)]
        [HttpGet("user")]
        public async Task<ActionResult<List<SimpleUser>>> Users()
        {
            var currentUserDto = userMapper.UserToCurrentUserDTO(User);
            var allUsers = await securityService.GetUsersForAsync(currentUserDto);
            var allUserDTO = allUsers.Select(user => new SimpleUser
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

        [Authorize(Policy = PolicyName.ReadPermissions)]
        [HttpGet("permission")]
        public async Task<IEnumerable<Permission>> GetAllPermissions()
        {
            return securityService.GetAllPermissions();
        }

        [Authorize(Policy = PolicyName.ReadRoles)]
        [HttpGet("role")]
        public async Task<IEnumerable<SimpleRoleDTO>> GetAllRoles()
        {
            return await securityService.GetAllRolesAsync();
        }

        [Authorize(Policy = PolicyName.ReadRoles)]
        [HttpGet("role/{id}")]
        public async Task<RoleDTO> GetRole(long id)
        {
            return await securityService.GetRoleAsync(id);
        }

        [Authorize(Policy = PolicyName.AssignPermissions)]
        [HttpPut("role")]
        public async Task<ActionResult> AssignPermissionToRole(AssignPermissionToRole assignPermissionsDTO)
        {
            await validator.AssignPermissionToRoleValidator().ValidateAndThrowAsync(assignPermissionsDTO);
            var serviceDto = new AssignPermissionsToRoleDTO
            {
                RoleId = assignPermissionsDTO.RoleId,
                Permissions = assignPermissionsDTO.Permissions
            };
            await securityService.AssignPermissionsToRoleAsync(serviceDto);
            return Ok();
        }

        [HttpPut("user")]
        public async Task<ActionResult> UserModification(UserModification userModificationDTO)
        {
            await validator.UserModificationValidator().ValidateAndThrowAsync(userModificationDTO);
            var serviceDto = new UserModificationDTO
            {
                UserId = userModificationDTO.UserId,
                IsEnabled = userModificationDTO.Enabled,
                Username = userModificationDTO.Username,
                Email = userModificationDTO.Email,
                Roles = userModificationDTO.Roles
            };
            var authResult = await authorizationService.AuthorizeAsync(User, serviceDto, new UpdateUserRequirement());
            if (!authResult.Succeeded)
            {
                return Forbid();
            }

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
