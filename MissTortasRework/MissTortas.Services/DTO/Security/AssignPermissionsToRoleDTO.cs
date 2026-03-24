using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MissTortas.Services.DTO.Security
{
    public class AssignPermissionsToRoleDTO
    {
        public long RoleId { get; set; }
        public List<string> Permissions { get; set; } = [];
    }
}
