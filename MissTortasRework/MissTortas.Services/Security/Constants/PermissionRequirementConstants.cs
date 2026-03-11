using MissTortas.Services.Security.Requirements;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Security.Constants
{
    public static class PermissionRequirementConstants
    {
        public static PermissionRequirement ViewAllUserPermission { get; set; } = new ("User", "ViewAll");
        public static PermissionRequirement ViewSelfUserPermission { get; set; } = new("User", "ViewSelf");
        public static PermissionRequirement ViewAllClaims { get; set; } = new("Claim", "ViewAll");
        public static PermissionRequirement RoleAssignClaim { get; set; } = new("Role", "AssignClaim");
        public static PermissionRequirement UpdateAllUser { get; set; } = new("User", "UpdateAll");
        public static PermissionRequirement UpdateSelfUser { get; set; } = new("User", "UpdateSelf");

    }
}
