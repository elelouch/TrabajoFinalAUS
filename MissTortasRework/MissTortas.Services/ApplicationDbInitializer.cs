using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Engine.Interfaces;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Security.Constants;


namespace MissTortas.Services
{
    public static class ApplicationDbInitializer
    {
        public static void SeedClaims(RoleManager<ApplicationRole> roleManager)
        {
            var adminRole = roleManager.FindByNameAsync(ApplicationRole.AdminRole.Name!).Result;
            if (adminRole != null)
            {
                foreach (var claim in ClaimConstants.AdminClaims)
                {
                    if (!roleManager.GetClaimsAsync(adminRole).Result.Any(c => c.Type == claim.Type && c.Value == claim.Value))
                    {
                        roleManager.AddClaimAsync(adminRole, claim).Wait();
                    }
                }
            }
            
            var userRole = roleManager.FindByNameAsync(ApplicationRole.UserRole.Name!).Result;
            if (userRole != null)
            {
                foreach (var claim in ClaimConstants.UserClaims)
                {
                    if (!roleManager.GetClaimsAsync(userRole).Result.Any(c => c.Type == claim.Type && c.Value == claim.Value))
                    {
                        roleManager.AddClaimAsync(userRole, claim).Wait();
                    }
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
            SeedClaims(roleManager);
        }

        public static void SeedRoles(RoleManager<ApplicationRole> roleManager)
        {
            var userRole = ApplicationRole.UserRole;
            var uRole = roleManager.FindByNameAsync(userRole.Name!);
            if(uRole.Result is null)
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

