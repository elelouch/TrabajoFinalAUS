using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Services.DTO.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Mapper.Interfaces
{
    public interface IRoleMapper
    {
        public SimpleRoleDTO RoleToSimpleDTO(ApplicationRole role);
        public IEnumerable<SimpleRoleDTO> RoleToSimpleDTO(IEnumerable<ApplicationRole> role);
        public RoleDTO RoleToDTO(ApplicationRole role);
    }
}
