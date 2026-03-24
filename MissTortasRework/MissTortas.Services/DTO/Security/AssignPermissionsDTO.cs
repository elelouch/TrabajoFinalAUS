using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.DTO.Security
{
    public class AssignPermissionsDTO
    {
        public AssignPermissionsToRoleDTO? RolePermissions { get; set; }
        public AssignPermissionToUserDTO? UserPermissions { get; set; }
    }
}
