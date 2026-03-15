using System.Security;
using System.Security.Claims;

namespace MissTortas.Data.Entity.Security.Permissions
{
    public class UserPermission : Permission
    {
        public override Claim AsClaim() => ((UserPermissionEnum)Value).ToClaim();
    }
    public enum UserPermissionEnum
    {
        ViewAll,
        ViewSelf,
        UpdateAll,
        UpdateSelf
    }
}
