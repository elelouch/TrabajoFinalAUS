using MissTortas.Services.DTO.Security;
using MissTortas.Services.Mapper.Interfaces;

namespace MissTortas.Services.Mapper
{
    public class RoleMapper : IRoleMapper
    {
        public RoleDTO RoleToDTO(ApplicationRole role)
        {
            var dto = new RoleDTO
            {
                Id = role.Id,
                Name = role.Name ?? "",
                Permissions = role.RoleClaims.Where(c => c.ClaimType == Permission.ClaimName).Select(c => c.ClaimValue)!
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
