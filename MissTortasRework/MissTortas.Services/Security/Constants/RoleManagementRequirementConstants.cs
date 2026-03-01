using MissTortas.Data.Entity.Security;
using MissTortas.Services.Security.Requirement;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Security.Constants
{
    public static class RoleManagementRequirementConstants
    {
        public static readonly RoleManagementRequirement roleManagementRequirement = new([
                RolePermission.CreateRole,
                RolePermission.RemoveRole,
                RolePermission.ViewRoles
            ]);
        public static readonly RoleManagementRequirement roleAssignationRequirement = new([
            RolePermission.AssociateRole,
            RolePermission.DeassociateRole,
    ]);
    }
}
