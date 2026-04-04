using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Permissions;

namespace MissTortas.Infrastructure.Mappings.Interfaces
{
    public interface IRoleMapper
    {
        public SimpleRoleDTO RoleToSimpleDTO(ApplicationRole role);
        public IEnumerable<SimpleRoleDTO> RoleToSimpleDTO(IEnumerable<ApplicationRole> role);
        public RoleDTO RoleWithPermissionsToDTO(ApplicationRole role, IEnumerable<Permission> permissions);
    }
}
