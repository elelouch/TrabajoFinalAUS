using MissTortas.Services.DTO.Security;

namespace MissTortas.Services.Mapper.Interfaces
{
    public interface IRoleMapper
    {
        public SimpleRoleDTO RoleToSimpleDTO(ApplicationRole role);
        public IEnumerable<SimpleRoleDTO> RoleToSimpleDTO(IEnumerable<ApplicationRole> role);
        public RoleDTO RoleToDTO(ApplicationRole role);
    }
}
