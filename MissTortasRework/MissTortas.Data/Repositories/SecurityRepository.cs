using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MissTortas.Data.Context;
using MissTortas.Data.Entity.Security.Permissions;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Data.Interfaces;

namespace MissTortas.Data.Repositories
{
    public class SecurityRepository(
        MissTortasContext context
        ) : RepositoryCrud<Permission>(context), ISecurityRepository
    {
        private readonly DbSet<Permission> permissionsSet  = context.Permissions;
        private readonly DbSet<PermissionCreateOrder> permissionsCreateOrderSet = context.CreateOrderPermissions;
        private readonly DbSet<PermissionRole> permissionsRoleSet = context.RolePermissions;
        private readonly DbSet<PermissionViewUser> permissionsViewUserSet = context.ViewUserPermissions;

        public async Task<bool> HasPermissionsAsync(long userId, IEnumerable<Permission> permissionsRequired)
        {
            var permissionsObtained = await permissionsSet.Include(p => p.Roles)
                .ThenInclude(r => r.Users)
                .Where(p => permissionsRequired.Any(perm => perm.Id == p.Id))
                .Where(p => p.Roles.Any(r => r.Users.Any(u => u.Id == userId)))
                .ToListAsync();
            return permissionsObtained.Count == permissionsRequired.Count();
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

        public IAsyncEnumerable<Permission> GetAllRolePermissionsFromUser(long userId)
        {
            return permissionsCreateOrderSet
                .Include(perm => perm.Roles)
                .ThenInclude(roles => roles.Users)
                .Where(perm => perm.Roles.Any(role => role.Users.Any(u => u.Id == userId)))
                .AsAsyncEnumerable();
        }

        public async Task<IEnumerable<Permission>?> FindAllPermissionsAsync(IEnumerable<long> permissionsIds)
        {
            var permissionsFound = permissionsSet.Where(p => permissionsIds.Any(permId => permId == p.Id));
            var allPermissionsAvailable = permissionsFound.Count() == permissionsIds.Count();
            if(allPermissionsAvailable)
            {
                return await permissionsFound.ToListAsync();
            }
            return null;
        }
    }
}
