using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Security.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services
{
    public static class ApplicationDbInitializer
    {
        public static void SeedDatabase(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedRoles(RoleManager<ApplicationRole> roleManager)
        {
            var userRole = ApplicationRole.UserRole;
            var uRole = roleManager.FindByNameAsync(userRole.Name!);
            uRole.Wait();
            if(uRole.Result is null)
            {
                roleManager.CreateAsync(userRole).Wait();
            }
            var adminRole = ApplicationRole.AdminRole;
            var aRole = roleManager.FindByNameAsync(adminRole.Name!);
            aRole.Wait();
            if (aRole.Result is null)
            {
                roleManager.CreateAsync(adminRole).Wait();
            }
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            var userTask = userManager.FindByEmailAsync("admin@admin.com");
            userTask.Wait();
            if (userTask.Result is null)
            {
                ApplicationUser newUser = new()
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };

                var createUserTask = userManager.CreateAsync(newUser, "C0rr0s!v3Cy4n!d3");
                createUserTask.Wait();
                if (createUserTask.Result.Succeeded)
                {
                    userManager.AddToRoleAsync(newUser, "Admin").Wait();
                }
            }
        }
    }
}
