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
    public class ViewUserHandler(ISecurityRepository securityRepository) : AuthorizationHandler<ViewUserRequirement>
    {
        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context, ViewUserRequirement requirement)
        {
            var userIdString = context.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("User must have a Name Identifier Claim.");
            var userId = long.Parse(userIdString);
            var viewPermissionsAvailable = await securityRepository.GetAllPermissionsFromUser<PermissionViewUser>(userId).ToListAsync();
            var viewUserPermissionRequired = requirement.ViewUserPermission;
            var userHasRequiredPermission = viewPermissionsAvailable.Any(perm => perm.ViewUserPermission == viewUserPermissionRequired);
            if (userHasRequiredPermission)
            {
                context.Succeed(requirement);
            }
        }
    }
}
