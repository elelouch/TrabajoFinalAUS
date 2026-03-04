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
using MissTortas.Services.DTO.User;

namespace MissTortas.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SecurityController(ISecurityService securityService) : Controller
    {
        private readonly int DefaultLockTime = 10000;

        [Authorize(Policy = "UserAdministrator")]
        [HttpGet("user")]
        public async Task<ActionResult<List<UserLogin>>> AllUser()
        {
            var allUsers = await userManager.Users.ToListAsync();
            var allUserDTO = new ArrayList(allUsers.Count);
            foreach (var user in allUsers)
            {
                allUserDTO.Add(new UserLogin { Id = user.Id, Username = user.UserName! });
            }
            return Ok(allUserDTO);
        }

        [AllowAnonymous]
        [HttpPost("user/login")]
        public async Task<ActionResult<UserLogin>> LoginUser(
                LoginRequest request
            )
        {

        }

        [Authorize(Policy = "RoleAssignment")]
        [HttpPost("role/permission/assignment")]
        public async Task<ActionResult> PostAssignPermissionToRole(AssignPermissionToRole assignPermissionsDTO)
        {
            var serviceDto = new AssignPermissionToRoleDTO
            {
                RoleName = assignPermissionsDTO.RoleName,
                PermissionsId = assignPermissionsDTO.PermissionsId
            };
            await securityService.AssignPermissionBulkAsync(serviceDto);
            return Ok();
        }

        [Authorize(Policy="ManageUsers")]
        [HttpPut]
        public async Task<ActionResult> PostUserModification(UserModification userModificationDTO)
        {
        }

        [AllowAnonymous]
        [HttpPost("user/register")]
        public async Task<ActionResult<UserLogin>> RegisterUser(RegisterRequest request)
        { 
        }


    }
}
