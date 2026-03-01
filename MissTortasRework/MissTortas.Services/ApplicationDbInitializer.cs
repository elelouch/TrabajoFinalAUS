using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Security;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Engine.Interfaces;
using MissTortas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services
{
    public static class ApplicationDbInitializer
    {
        public static void SeedPermissions(ISecurityService securityService)
        {
            var createPermissionsTask = securityService.CreatePermissionBulkAsync(Permission.permissions);
            createPermissionsTask.Wait();
            var allPermissions = securityService.GetAllPermissions().Result;
            var assignPermissionToAdminTask = 
                securityService.AssignPermissionBulkAsync(ApplicationRole.AdminRole.Name!, allPermissions);
            assignPermissionToAdminTask.Wait();
        }

        public static void SeedDatabase(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            ISecurityService securityService
            )
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
            SeedPermissions(securityService);
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
