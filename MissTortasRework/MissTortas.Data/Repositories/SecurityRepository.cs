using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MissTortas.Data.Context;
using MissTortas.Data.Entity.Security;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Data.Interfaces;

namespace MissTortas.Data.Repositories
{
    public class SecurityRepository(MissTortasContext context) : RepositoryCrud<Permission>(context), ISecurityRepository
    {
        private readonly DbSet<PermissionRole> permissionForRoles = context.PermissionRoles;

        public bool HasRolePermission(long userId, IEnumerable<RolePermission> rolePermissions)
        {
            var permissions = rolePermissions.Select(r => (int)r).ToList();
            var count = permissionForRoles
                .Include(pfr => pfr.Roles)
                .ThenInclude(roles => roles.Users)
                .Where(pfr => pfr.Roles.Any(r => r.Users.Any(u => u.Id == userId)) && rolePermissions.Contains(pfr.RolePermission))
                .GroupBy(pfr => pfr.RolePermission)
                .Count();
            return count == rolePermissions.Count();
        }

    }
}
