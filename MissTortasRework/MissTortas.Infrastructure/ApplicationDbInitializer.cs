using Microsoft.AspNetCore.Identity;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Permissions;
using System.Security.Claims;


namespace MissTortas.Infrastructure
{
    public static class ApplicationDbInitializer
    {
        public static void SeedPermissions(RoleManager<ApplicationRole> roleManager)
        {
            var allPermissions = Permission.All;
            var adminRole = roleManager.FindByNameAsync(ApplicationRole.AdminRole.Name!).Result;

            var adminPermissionsAssigned = roleManager.GetClaimsAsync(adminRole!).Result.Where(c => c.Type == Permission.ClaimName);
            foreach (var p in allPermissions)
            {
                if (!adminPermissionsAssigned.Any(pAssigned => pAssigned.Value == p.Code))
                {
                    roleManager.AddClaimAsync(adminRole!, new Claim(Permission.ClaimName, p.Code)).Wait();
                }
            }

            List<Permission> userRolePermission = [Permission.ReadSelfUser];
            var userRole = roleManager.FindByNameAsync(ApplicationRole.UserRole.Name!).Result;
            var userPermissionsAssigned = roleManager.GetClaimsAsync(userRole!).Result.Where(c => c.Type == Permission.ClaimName);
            foreach (var p in userRolePermission)
            {
                if (!userPermissionsAssigned.Any(pAssigned => pAssigned.Value == p.Code))
                {
                    roleManager.AddClaimAsync(userRole!, new Claim(Permission.ClaimName, p.Code)).Wait();
                }
            }

        }

        public static void SeedDatabase(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager
        )
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
            SeedPermissions(roleManager);
        }

        public static void SeedRoles(RoleManager<ApplicationRole> roleManager)
        {
            var userRole = ApplicationRole.UserRole;
            var uRole = roleManager.FindByNameAsync(userRole.Name!);
            if (uRole.Result is null)
            {
                roleManager.CreateAsync(userRole).Wait();
            }
            var adminRole = ApplicationRole.AdminRole;
            var aRole = roleManager.FindByNameAsync(adminRole.Name!);
            if (aRole.Result is null)
            {
                roleManager.CreateAsync(adminRole).Wait();
            }
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            var userTask = userManager.FindByEmailAsync("admin@admin.com");
            if (userTask.Result is null)
            {
                ApplicationUser newUser = new()
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };

                var createUserTask = userManager.CreateAsync(newUser, "C0rr0s!v3Cy4n!d3");
                if (createUserTask.Result.Succeeded)
                {
                    userManager.AddToRoleAsync(newUser, ApplicationRole.AdminRole.Name!).Wait();
                }
            }
        }
    }
}

