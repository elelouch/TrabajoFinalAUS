using Microsoft.AspNetCore.Authorization;
using MissTortas.Data.Entity.Security.Permissions;
using MissTortas.Data.Interfaces;
using MissTortas.Services.Security.Requirement;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MissTortas.Services.Security.Handler
{
    public class UserRequirementHandler(ISecurityRepository repository) : AuthorizationHandler<UserRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRequirement requirement)
        {
            var userIdString = context.User.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? throw new InvalidOperationException("User must have a Name Identifier Claim.");
            var userId = long.Parse(userIdString);

            var permissionsAvailable = await repository.GetAllPermissionsFromUser<PermissionUser>(userId).ToListAsync();
            var hasRequiredPermission = permissionsAvailable.Any(permission => permission.UserPermisison == requirement.RequiredPermission);

            if (hasRequiredPermission)
            {
                context.Succeed(requirement);
            }
        }
    }
}
