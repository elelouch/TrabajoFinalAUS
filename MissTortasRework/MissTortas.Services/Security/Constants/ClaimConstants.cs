using MissTortas.Data.Entity.Security.Permissions;
using System.Security.Claims;

namespace MissTortas.Services.Security.Constants
{
    public static class ClaimConstants
    {
        public static readonly Claim ViewAllUser = UserPermissionEnum.ViewAll.ToClaim();
        public static readonly Claim ViewSelf = UserPermissionEnum.ViewSelf.ToClaim();
        public static readonly Claim UpdateAllUser = UserPermissionEnum.UpdateAll.ToClaim();
        public static readonly Claim UpdateSelfUser = UserPermissionEnum.UpdateSelf.ToClaim();
        public static readonly Claim ViewAllClaims = ClaimPermissionEnum.ViewAll.ToClaim();
        public static readonly Claim RoleViewAll = RolePermissionEnum.ViewAll.ToClaim();
        public static readonly Claim RoleAssignClaim = RolePermissionEnum.AssignClaim.ToClaim();

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