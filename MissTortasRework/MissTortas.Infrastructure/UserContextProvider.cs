using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MissTortas.Infrastructure.Entity;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Services;
using MissTortas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MissTortas.Infrastructure
{
    public class UserContextProvider(
        IHttpContextAccessor httpContextAccessor, 
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager
    ) : IUserContextProvider
    {
        public async Task<UserContext> GetCurrentAsync()
        {
            var user = httpContextAccessor.HttpContext?.User;
            var userId = user?.FindFirstValue("sub");
            var userIsAuthenticated = user?.Identity?.IsAuthenticated ?? false;
            if (string.IsNullOrEmpty(userId) || !userIsAuthenticated)
            {
                var guestRole = await roleManager.FindByNameAsync(UserConstants.GuestRoleName);
                return new UserContext
                {
                    IsAuthenticated = false,
                    UserId = 0,
                    Roles = [],
                    DefaultSubjectId = guestRole?.RoleId ?? 0
                };
            }

            var applicationUser = await userManager.FindByIdAsync(userId) ?? throw new InvalidOperationException("User not found.");
            return new UserContext
            {
                IsAuthenticated = true,
                UserId = applicationUser.UserId,
                Roles = user?.Claims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value)
                    .ToList() ?? []
            };
        }
    }
}
