using MissTortas.Data.Entity.Security.Permissions;

namespace MissTortas.Data.Interfaces
{
    public interface ISecurityRepository
    {
        public IAsyncEnumerable<Permission> GetAllPermissions();
    }
}
