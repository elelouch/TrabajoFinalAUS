using Microsoft.EntityFrameworkCore;
using MissTortas.Data.Context;
using MissTortas.Data.Entity.Security.Permissions;
using MissTortas.Data.Interfaces;

namespace MissTortas.Data.Repositories
{
    public class SecurityRepository(MissTortasContext context) : ISecurityRepository
    {
        public DbSet<Permission> permissionSet = context.Permissions;

        public IAsyncEnumerable<Permission> GetAllPermissions()
        {
            return context.Permissions.ToAsyncEnumerable();
        }
    }
}
