using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

            var allPermissions = Permission.All;

            var adminRole = await roleManager.FindByNameAsync(UserConstants.AdminRoleName) ?? throw new InvalidOperationException("Admin role not seeded.");

            var adminPermissionsAssigned = (await roleManager.GetClaimsAsync(adminRole))
                .Where(c => c.Type == Permission.ClaimName)
                .Select(c => c.Value)
                .ToHashSet();

            foreach (var p in allPermissions)
            {
                if (!adminPermissionsAssigned.Contains(p.Code))
                {
                    await roleManager.AddClaimAsync(adminRole!, new Claim(Permission.ClaimName, p.Code));
                }
            }

            List<Permission> userRolePermission = [Permission.ReadSelfUser];

            var userRole = await roleManager.FindByNameAsync(UserConstants.AdminRoleName) ?? throw new InvalidOperationException("Admin role not seeded.");

            var userPermissionsAssigned = (await roleManager.GetClaimsAsync(userRole!))
                .Where(c => c.Type == Permission.ClaimName)
                .Select(c => c.Value)
                .ToHashSet();

            foreach (var p in userRolePermission)
            {
                if (!userPermissionsAssigned.Contains(p.Code))
                {
                    await roleManager.AddClaimAsync(userRole!, new Claim(Permission.ClaimName, p.Code));
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
            // load user
            var userDomainRole = await context.DomainRoles.FirstOrDefaultAsync(u => u.Name == UserConstants.UserRoleName);
            if (userDomainRole is null)
            {
                userDomainRole = new Role { Name = UserConstants.UserRoleName };
                await context.DomainRoles.AddAsync(userDomainRole);
                await context.SaveChangesAsync();
            }
            var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
            var appUserRole = await roleManager.FindByNameAsync(UserConstants.UserRoleName);
            if (appUserRole is null)
            {
                appUserRole = new ApplicationRole { RoleId = userDomainRole.Id, Name = UserConstants.UserRoleName };
                await roleManager.CreateAsync(appUserRole);
            }
            // load admin
            var adminDomainRole = await context.DomainRoles.FirstOrDefaultAsync(u => u.Name == UserConstants.AdminRoleName);
            if (adminDomainRole is null)
            {
                adminDomainRole = new Role { Name = UserConstants.AdminRoleName };
                await context.DomainRoles.AddAsync(adminDomainRole);
                await context.SaveChangesAsync();
            }
            var appAdminRole = await roleManager.FindByNameAsync(UserConstants.AdminRoleName);
            if (appAdminRole is null)
            {
                appAdminRole = new ApplicationRole { Name = UserConstants.AdminRoleName, RoleId = adminDomainRole.Id };
                await roleManager.CreateAsync(appAdminRole);
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

