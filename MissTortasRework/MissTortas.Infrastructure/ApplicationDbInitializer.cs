using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MissTortas.Domain.Security.Contacts;
using MissTortas.Domain.Security.Users;
using MissTortas.Infrastructure.Context;
using MissTortas.Infrastructure.Entity;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Permissions;
using System.Security.Claims;


namespace MissTortas.Infrastructure
{
    public static class ApplicationDbInitializer
    {
        public static async Task SeedPermissionsAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

            var adminRole = await GetRoleOrThrowAsync(roleManager, UserConstants.AdminRoleName);
            await AddPermissionsToRoleAsync(roleManager, adminRole, Permission.All);

            var userRole = await GetRoleOrThrowAsync(roleManager, UserConstants.UserRoleName);
            await AddPermissionsToRoleAsync(roleManager, userRole, [Permission.ReadSelfUser]);
        }

        private static async Task<ApplicationRole> GetRoleOrThrowAsync(RoleManager<ApplicationRole> roleManager, string roleName)
        {
            return await roleManager.FindByNameAsync(roleName)
                ?? throw new InvalidOperationException($"{roleName} role not seeded.");
        }

        private static async Task AddPermissionsToRoleAsync(RoleManager<ApplicationRole> roleManager, ApplicationRole role, IEnumerable<Permission> permissions)
        {
            var existingPermissions = (await roleManager.GetClaimsAsync(role))
                .Where(c => c.Type == Permission.ClaimName)
                .Select(c => c.Value)
                .ToHashSet();

            foreach (var permission in permissions)
            {
                if (!existingPermissions.Contains(permission.Code))
                {
                    await roleManager.AddClaimAsync(role, new Claim(Permission.ClaimName, permission.Code));
                }
            }
        }

        public static async Task SeedDatabaseAsync(IServiceProvider services)
        {
            await SeedRolesAsync(services);
            await SeedUsersAsync(services);
            await SeedPermissionsAsync(services);
        }

        public static async Task SeedRolesAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<MissTortasContext>();
            var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

            // Define required roles
            var requiredRoles = new[]
            {
                UserConstants.AdminRoleName,
                UserConstants.UserRoleName,
                UserConstants.GuestRoleName
            };

            foreach (var roleName in requiredRoles)
            {
                await EnsureRoleExistsAsync(roleName, context, roleManager);
            }
        }

        private static async Task EnsureRoleExistsAsync(string roleName, MissTortasContext context, RoleManager<ApplicationRole> roleManager)
        {
            var domainRole = await context.DomainRoles.FirstOrDefaultAsync(r => r.Name == roleName);
            if (domainRole is null)
            {
                domainRole = new Role { Name = roleName };
                await context.DomainRoles.AddAsync(domainRole);
                await context.SaveChangesAsync();
            }
            var appRole = await roleManager.FindByNameAsync(roleName);
            if (appRole is null)
            {
                appRole = new ApplicationRole { RoleId = domainRole.Id, Name = roleName };
                await roleManager.CreateAsync(appRole);
            }
        }

        public async static Task SeedUsersAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<MissTortasContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var domainUser = await context.DomainUsers.FirstOrDefaultAsync(u => u.FirstName == UserConstants.AdminUserName && u.LastName == UserConstants.AdminUserName);
            if (domainUser == null)
            {
                domainUser = new User
                {
                    FirstName = UserConstants.AdminUserName,
                    LastName = UserConstants.AdminUserName,
                    Birthday = new DateOnly(2000, 1, 1)
                };

                await context.DomainUsers.AddAsync(domainUser);
                await context.SaveChangesAsync();
            }

            var identityUser = await userManager.FindByNameAsync(UserConstants.AdminUserName);

            if (identityUser is null)
            {
                ApplicationUser newUser = new()
                {
                    UserId = domainUser.Id,
                    UserName = UserConstants.AdminUserName,
                    Email = "admin@admin.com"
                };

                var createUserTask = await userManager.CreateAsync(newUser, "C0rr0s!v3Cy4n!d3");
                if (createUserTask.Succeeded)
                {
                    await userManager.AddToRoleAsync(newUser, UserConstants.AdminRoleName);
                }
            }
        }
    }
}

