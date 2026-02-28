using MissTortas.Data.Context;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Data.Interfaces;

namespace MissTortas.Data.Repositories
{
    public class SecurityRepository(MissTortasContext context) : ISecurityRepository
    {
        public PermissionUser? UserHasViewPermission(long userId, ViewUserPermission userPermission)
        {
            throw new NotImplementedException();
        }
    }
}
