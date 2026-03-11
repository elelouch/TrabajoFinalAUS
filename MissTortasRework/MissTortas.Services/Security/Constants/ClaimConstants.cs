using System.Security.Claims;

namespace MissTortas.Services.Security.Constants
{
    public static class ClaimConstants
    {
        public static readonly Claim ViewAllUser = new(PermissionRequirementConstants.ViewAllUserPermission.ClaimType, PermissionRequirementConstants.ViewAllUserPermission.ClaimValue);
        public static readonly Claim ViewSelf = new(PermissionRequirementConstants.ViewSelfUserPermission.ClaimType, PermissionRequirementConstants.ViewSelfUserPermission.ClaimValue);
        public static readonly Claim ViewAllClaims = new(PermissionRequirementConstants.ViewAllClaims.ClaimType, PermissionRequirementConstants.ViewAllClaims.ClaimValue);
        public static readonly Claim UpdateAllUser = new(PermissionRequirementConstants.UpdateAllUser.ClaimType, PermissionRequirementConstants.UpdateAllUser.ClaimValue);
        public static readonly Claim UpdateSelfUser = new(PermissionRequirementConstants.UpdateSelfUser.ClaimType, PermissionRequirementConstants.UpdateSelfUser.ClaimValue);
        public static readonly Claim RoleAssignClaim = new(PermissionRequirementConstants.RoleAssignClaim.ClaimType, PermissionRequirementConstants.RoleAssignClaim.ClaimValue);

        public static readonly List<Claim> AllClaims = 
        [
            ViewAllUser,
            ViewSelf,
            ViewAllClaims,
            UpdateAllUser,
            UpdateSelfUser,
            RoleAssignClaim
        ];

        public static readonly List<Claim> AdminClaims =
        [
            ViewAllUser,
            ViewAllClaims,
            UpdateAllUser,
            RoleAssignClaim
        ];

        public static readonly List<Claim> UserClaims =
        [
            ViewSelf,
            UpdateSelfUser
        ];
    }
}