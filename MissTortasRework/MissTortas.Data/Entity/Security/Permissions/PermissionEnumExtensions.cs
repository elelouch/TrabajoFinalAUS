using System.Security.Claims;

namespace MissTortas.Data.Entity.Security.Permissions
{
    public static class PermissionEnumExtensions
    {
        public static Claim ToClaim(this Enum permissionEnum)
        {
            var permission = permissionEnum.ToString();

            return permissionEnum switch
            {
                UserPermissionEnum => new Claim(PermissionTypeEnum.User.ToString(), permission),
                RolePermissionEnum => new Claim(PermissionTypeEnum.Role.ToString(), permission),
                ClaimPermissionEnum => new Claim(PermissionTypeEnum.Claim.ToString(), permission),
                _ => throw new InvalidOperationException("Enum permission does not exist")
            };
        }
    }

}
