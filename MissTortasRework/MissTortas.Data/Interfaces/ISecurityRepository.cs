using MissTortas.Data.Entity.Security.Permissions;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Data.Repositories;

namespace MissTortas.Data.Interfaces
{
    public interface ISecurityRepository : IRepositoryCrud<Permission>
    {
        public Task<IEnumerable<Permission>?> FindAllPermissionsAsync(IEnumerable<long> permissionsIds);
        public IAsyncEnumerable<Permission> GetAllPermissions();
        public Task<IEnumerable<Permission>?> FindAllPermissionAsync(IEnumerable<string> permissionNames);
        public Task<bool> HasPermissionsAsync(long userId, IEnumerable<Permission> permissions);
        public IAsyncEnumerable<T> GetAllPermissionsFromUser<T>(long userId) where T: Permission;
    }
}
