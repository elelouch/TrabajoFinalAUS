using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Security;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Data.Interfaces;
using MissTortas.Services.Interfaces;

namespace MissTortas.Services
{
    public class SecurityService(
        ISecurityRepository securityRepository,
        RoleManager<ApplicationRole> roleManager
        ) : ISecurityService
    {
        public async Task CreatePermissionBulkAsync(IEnumerable<Permission> permissionBulk)
        {
            var permissions = await securityRepository.FindAllPermissionAsync(permissionBulk.Select(p => p.Name));
            if(permissions is null)
            {
                await securityRepository.BulkInsertPermissionsAsync(permissionBulk);
            }
            await securityRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Permission>> GetAllPermissions()
        {
            var permissions = securityRepository.GetAllPermissions();
            return await permissions.ToListAsync();
        }

        public async Task AssignPermissionBulkAsync(string roleName, IEnumerable<Permission> permissionBulk)
        {
            var role = await roleManager.FindByNameAsync(roleName) ?? throw new InvalidOperationException("Role does not exists.");
            foreach (var p in permissionBulk)
            {
                role.Permissions.Add(p);
            }
            await securityRepository.SaveChangesAsync();
        }
    }
}
