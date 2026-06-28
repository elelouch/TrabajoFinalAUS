using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Interface;
using MissTortas.View.DTO.Security;

namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController(ISecurityService securityService, IValidator<ModifyApplicationRole> assignPermissionValidator) : ControllerBase
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
            var ret = await securityService.GetRoleByNameAsync(id);
            if (ret is null)
            {
                return NotFound();
            }
            return ret;
        }

        [Authorize(Policy = PolicyName.AssignPermissions)]
        [HttpPut("{id}")]
        public async Task<ActionResult> AssignPermissionToRole(long id, ModifyApplicationRole assignPermissionsDTO)
        {
            await assignPermissionValidator.ValidateAndThrowAsync(assignPermissionsDTO);
            var serviceDto = new ModifyRoleDTO
            {
                RoleId = id,
                Name = assignPermissionsDTO.Name,
                Permissions = assignPermissionsDTO.Permissions
            };
            await securityService.ModifyRoleAsync(serviceDto);
            return Ok();
        }
    }
}
