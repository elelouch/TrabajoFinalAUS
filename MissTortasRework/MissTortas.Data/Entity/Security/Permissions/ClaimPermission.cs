using System.Security.Claims;

namespace MissTortas.Data.Entity.Security.Permissions
{
    public class ClaimPermission : Permission
    {
        public override Claim AsClaim() => ((ClaimPermissionEnum)Value).ToClaim();

    }
    public enum ClaimPermissionEnum
    {
        ViewAll
    }
}
