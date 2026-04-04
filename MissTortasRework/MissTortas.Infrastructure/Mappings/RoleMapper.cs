using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Infrastructure.Mappings.Interfaces;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Permissions;

namespace MissTortas.Infrastructure.Mappings
{
    public class RoleMapper : IRoleMapper
    {
        public RoleDTO RoleWithPermissionsToDTO(ApplicationRole role, IEnumerable<Permission> permissions)
        {
            var dto = new RoleDTO
            {
                Id = role.Id,
                Name = role.Name ?? "",
                Permissions = permissions.Select(p => p.Code)
            };
            return dto;
        }

        public SimpleRoleDTO RoleToSimpleDTO(ApplicationRole role)
        {
            var dto = new SimpleRoleDTO
            {
                Id = role.Id,
                Name = role.Name ?? ""
            };
            return dto;
        }
        public IEnumerable<SimpleRoleDTO> RoleToSimpleDTO(IEnumerable<ApplicationRole> roles)
        {
            return roles.Select(r => RoleToSimpleDTO(r));
        }
    }
}
