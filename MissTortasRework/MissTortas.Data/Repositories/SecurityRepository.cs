using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MissTortas.Data.Context;
using MissTortas.Data.Entity.Security;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Data.Interfaces;

namespace MissTortas.Data.Repositories
{
    public class SecurityRepository(
        MissTortasContext context
        ) : RepositoryCrud<Permission>(context), ISecurityRepository
    {
        private readonly DbSet<Permission> permissionsSet  = context.Permissions;

        public bool HasPermissionAsync(long userId, IEnumerable<string> permissionName)
        {
            var permission = await permissionsSet.Include(p => p.Roles)
                .ThenInclude(r => r.Users)
                .Where(p => permissionName.Any(name => name == p.Name))
                .Where(p => p.Roles.Any(r => r.Users.Any(u => u.Id == userId)))
                .ToListAsync();
            return 
        }
        public async Task BulkInsertPermissionsAsync(IEnumerable<Permission> permissions)
        {
            await permissionsSet.AddRangeAsync(permissions);
        }

        public async Task<IEnumerable<Permission>?> FindAllPermissionAsync(IEnumerable<string> permissionNames)
        {
            var permissions = await permissionsSet.Where(p => permissionNames.Any(name => name == p.Name)).ToListAsync();
            return permissions.Count == permissionNames.Count() ? permissions : null;
        }

        public IAsyncEnumerable<Permission> GetAllPermissions()
        {
            return permissionsSet.AsAsyncEnumerable();
        }
    }
}
