using System.Security.Claims;

namespace MissTortas.Data.Entity.Security.Permissions
{
    public class RolePermission : Permission
    {
        public override Claim AsClaim() => ((RolePermissionEnum)Value).ToClaim();
    }
    public enum RolePermissionEnum
    {
        AssignClaim,
        ViewAll,
        ViewSelf
    }
}
