using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MissTortas.Infrastructure.Entity;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Permissions;
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
            var userPrincipal = httpContextAccessor.HttpContext?.User;
            var userId = userPrincipal?.FindFirstValue("sub");
            var userIsAuthenticated = userPrincipal?.Identity?.IsAuthenticated ?? false;
            if (string.IsNullOrEmpty(userId) || !userIsAuthenticated)
            {
                var guestRole = await roleManager.Roles
                    .Select(r => new {r.Role.SubjectId, r.NormalizedName})
                    .Where(r => r.NormalizedName != null && r.NormalizedName == UserConstants.GuestRoleName)
                    .SingleAsync();
                return new UserContext
                {
                    IsAuthenticated = false,
                    UserId = 0,
                    Roles = [UserConstants.GuestRoleName],
                    RelatedSubjectId = [guestRole.SubjectId]
                };
            }

            var appUser = await userManager.Users
                .Select(user => new {user.UserId, user.Id, user.User.SubjectId, RolesSubjectId = user.User.Roles.Select(r => r.SubjectId)})
                .Where(user => user.Id == userId)
                .SingleAsync();
            return new UserContext
            {
                IsAuthenticated = true,
                UserId = appUser.UserId,
                AppUserId = appUser.Id,
                Roles = userPrincipal?.Claims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value)
                    .ToList() ?? [],
                Permissions = userPrincipal?.Claims
                    .Where(c => c.Type == Permission.ClaimName)
                    .Select(c => c.Value)
                    .ToList() ?? [],
                RelatedSubjectId = [appUser.SubjectId, ..appUser.RolesSubjectId]
            };
        }
    }
}
