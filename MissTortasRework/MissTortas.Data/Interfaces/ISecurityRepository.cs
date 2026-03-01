using MissTortas.Data.Entity.Security;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Data.Repositories;

namespace MissTortas.Data.Interfaces
{
    public interface ISecurityRepository : IRepositoryCrud<Permission>
    {
        public IAsyncEnumerable<Permission> GetAllPermissions();
        public Task BulkInsertPermissionsAsync(IEnumerable<Permission> permission);
        public Task<IEnumerable<Permission>?> FindAllPermissionAsync(IEnumerable<string> permissionNames);
    }
}
