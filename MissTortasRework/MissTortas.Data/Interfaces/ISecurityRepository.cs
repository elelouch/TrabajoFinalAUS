using MissTortas.Data.Entity.Security;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Data.Repositories;

namespace MissTortas.Data.Interfaces
{
    public interface ISecurityRepository : IRepositoryCrud<Permission>
    {
        //public bool HasViewPermission (long userId, ViewUserPermission userPermission);
        //public bool HasRolePermission(long userId, IEnumerable<RolePermission> rolePermissions);
    }
}
