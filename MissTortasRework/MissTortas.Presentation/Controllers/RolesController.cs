using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Interface;
using MissTortas.Presentation.DTO.Security;
using System.ComponentModel.DataAnnotations;

namespace MissTortas.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController(ISecurityService securityService, IValidator<AssignPermissionToRole> assignPermissionValidator) : Controller
    {
        [Authorize(Policy = PolicyName.ReadRoles)]
        [HttpGet]
        public async Task<IEnumerable<SimpleRoleDTO>> GetAllRoles()
        {
            return await securityService.GetAllRolesAsync();
        }

        [Authorize(Policy = PolicyName.ReadRoles)]
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTO>> GetRole(string id)
        {
            var ret = await securityService.GetRoleAsync(id);
            if (ret is null)
            {
                return NotFound();
            }
            return ret;
        }

        [Authorize(Policy = PolicyName.AssignPermissions)]
        [HttpPut]
        public async Task<ActionResult> AssignPermissionToRole(AssignPermissionToRole assignPermissionsDTO)
        {
            await assignPermissionValidator.ValidateAndThrowAsync(assignPermissionsDTO);
            var serviceDto = new AssignPermissionsToRoleDTO
            {
                RoleId = assignPermissionsDTO.RoleId,
                Permissions = assignPermissionsDTO.Permissions
            };
            await securityService.AssignPermissionsToRoleAsync(serviceDto);
            return Ok();
        }
    }
}
