using MissTortas.Data.Entity.Security.Permissions;
using MissTortas.Services.Security.Requirements;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Security.Constants
{
    public static class PermissionRequirementConstants
    {
        public static PermissionRequirement ViewAllUser { get; } = new([UserPermissionEnum.ViewAll.ToClaim()]);
        public static PermissionRequirement ViewSelfUser { get; } = new([UserPermissionEnum.ViewSelf.ToClaim()]);
        public static PermissionRequirement UpdateAllUser { get; } = new([UserPermissionEnum.UpdateAll.ToClaim()]);
        public static PermissionRequirement UpdateSelfUser { get; } = new([UserPermissionEnum.UpdateSelf.ToClaim()]);
        public static PermissionRequirement RoleAssignClaim { get; } = new([RolePermissionEnum.AssignClaim.ToClaim()]);
        public static PermissionRequirement RoleViewAll { get; } = new([RolePermissionEnum.ViewAll.ToClaim()]);
        public static PermissionRequirement ClaimViewAll { get; } = new([ClaimPermissionEnum.ViewAll.ToClaim()]);
    }

}
