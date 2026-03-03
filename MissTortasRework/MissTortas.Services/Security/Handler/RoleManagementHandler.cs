using Microsoft.AspNetCore.Authorization;
using MissTortas.Data.Entity.Security;
using MissTortas.Data.Entity.Security.Permissions;
using MissTortas.Data.Interfaces;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Security.Requirement;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MissTortas.Services.Security.Handler
{
    public class RoleManagementHandler(ISecurityRepository repository) : AuthorizationHandler<RoleManagementRequirement>
    {

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleManagementRequirement requirement)
        {
            var userIdString = context.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("User must have a Name Identifier Claim.");
            var userId = long.Parse(userIdString);
            var permissionsAvailable = await repository.GetAllRolePermissionsFromUser(userId).ToListAsync();
            var permissionsRequired = requirement.RolePermissions;
            var allRequiredPermissionsAreMet = permissionsRequired.All(
                permRequired => permissionsAvailable.Any(available => available.Value == (int)permRequired)
            );

            if(allRequiredPermissionsAreMet)
            {
                context.Succeed(requirement);
            }
            
        }
    }
}
