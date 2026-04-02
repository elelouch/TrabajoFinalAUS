using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Infrastructure.Security.Identity;

namespace MissTortas.Infrastructure.Mappings.Interfaces
{
    public interface IRoleMapper
    {
        public SimpleRoleDTO RoleToSimpleDTO(ApplicationRole role);
        public IEnumerable<SimpleRoleDTO> RoleToSimpleDTO(IEnumerable<ApplicationRole> role);
        public RoleDTO RoleToDTO(ApplicationRole role);
    }
}
