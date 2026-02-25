using MissTortas.Data.Entity.Security.User;

namespace MissTortas.Data.Interfaces
{
    public interface ISecurityRepository
    {
        public PermissionUser? UserHasViewPermission (long userId, ViewUserPermission userPermission);
    }
}
