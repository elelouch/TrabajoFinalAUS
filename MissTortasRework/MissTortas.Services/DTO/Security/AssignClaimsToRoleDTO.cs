using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MissTortas.Services.DTO.Security
{
    public class AssignClaimsToRoleDTO
    {
        public long RoleId { get; set; }
        public List<Claim> Claims { get; set; } = [];
    }
}
