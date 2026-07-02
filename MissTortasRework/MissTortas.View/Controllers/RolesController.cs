using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Interface;
using MissTortas.Services.Interfaces;
using MissTortas.View.DTO.Security;

namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController(
        ISecurityService securityService,
        IValidator<ModifyApplicationRole> assignPermissionValidator,
        IValidator<CreateRoleRequest> createRoleRequestValidator
    ) : ControllerBase
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
            var ret = await securityService.FindRoleByIdAsync(id);
            if (ret is null)
            {
                return NotFound();
            }
            return ret;
        }

        [Authorize(Policy = PolicyName.AssignPermissions)]
        [HttpPut("{id}")]
        public async Task<ActionResult> AssignPermissionToRole(string id, ModifyApplicationRole assignPermissionsDTO)
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

        [Authorize(Policy = PolicyName.AssignPermissions)]
        [HttpPost]
        public async Task<ActionResult<SimpleRoleDTO>> CreateRoles(CreateRoleRequest createRoleRequest)
        {
            await createRoleRequestValidator.ValidateAndThrowAsync(createRoleRequest);
            var role = await securityService.CreateRoleAsync(createRoleRequest.Name);
            return Ok(role);
        }
    }
}
