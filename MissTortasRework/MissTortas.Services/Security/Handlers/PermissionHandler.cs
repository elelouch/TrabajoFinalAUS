using Microsoft.AspNetCore.Authorization;
using MissTortas.Data.Entity.Security.Permissions;
using MissTortas.Services.Security.Requirements;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MissTortas.Services.Security.Handlers
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var hasAllPermissions = requirement.PermissionsRequired
                .Select(p => p.Name)
                .Any(p => context.User.HasClaim(Permission.ClaimName, p));

            if (hasAllPermissions) 
                context.Succeed(requirement);
        }
    }
}
