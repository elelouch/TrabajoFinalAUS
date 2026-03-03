using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.DTO.Security
{
    public class AssignPermissionToRoleDTO
    {
        public string RoleName { get; set; } = string.Empty;
        public List<long> PermissionsId { get; set; } = [];
    }
}
