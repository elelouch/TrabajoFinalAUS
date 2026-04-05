using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MissTortas.Domain.Security.Users;
using MissTortas.Infrastructure.Context;
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

            var adminRole = await roleManager.FindByNameAsync(ApplicationRole.AdminRole.Name!) ?? throw new InvalidOperationException("Admin role not seeded.");

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

            var userRole = await roleManager.FindByNameAsync(ApplicationRole.UserRole.Name!) ?? throw new InvalidOperationException("Admin role not seeded.");

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
        public static async Task SeedDatabase(IServiceProvider services)
        {
            await SeedRolesAsync(services);
            await SeedUsers(services);
            await SeedPermissionsAsync(services);
        }

        public static async Task SeedRolesAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

            var userRole = ApplicationRole.UserRole;
            var existingUserRole = await roleManager.FindByNameAsync(userRole.Name!);

            if (existingUserRole is null)
            {
                await roleManager.CreateAsync(userRole);
            }

            var adminRole = ApplicationRole.AdminRole;
            var existingAdminRole = await roleManager.FindByNameAsync(adminRole.Name!);

            if (existingAdminRole is null)
            {
                await roleManager.CreateAsync(adminRole);
            }
        }

        public async static Task SeedUsers(IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<MissTortasContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var userTask = userManager.FindByEmailAsync("admin@admin.com");

            var domainUser = await context.DomainUsers.FirstOrDefaultAsync(u => u.FirstName == "Admin" && u.LastName == "Admin");
            if (domainUser == null)
            {
                domainUser = new User
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    Birthday = new DateOnly(2000, 1, 1)
                };

                await context.DomainUsers.AddAsync(domainUser);
                await context.SaveChangesAsync();
            }

            var identityUser = await userManager.FindByNameAsync("admin");

            if (identityUser is null)
            {
                ApplicationUser newUser = new()
                {
                    UserId = domainUser.Id,
                    UserName = "admin",
                    Email = "admin@admin.com"
                };

                var createUserTask = await userManager.CreateAsync(newUser, "C0rr0s!v3Cy4n!d3");
                if (createUserTask.Succeeded)
                {
                    userManager.AddToRoleAsync(newUser, ApplicationRole.AdminRole.Name!).Wait();
                }
            }
        }
    }
}

