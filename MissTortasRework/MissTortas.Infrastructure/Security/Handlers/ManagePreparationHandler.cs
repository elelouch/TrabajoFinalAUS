using Microsoft.AspNetCore.Authorization;
using MissTortas.Infrastructure.Security.Permissions;
using MissTortas.Infrastructure.Security.Requirements;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Infrastructure.Security.Handlers
{
    public class ManagePreparationHandler : AuthorizationHandler<ManageAssignedPreparationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageAssignedPreparationRequirement requirement)
        {
            if(context.User.FindFirst(c => c.Type == Permission.ClaimName && c.Value == Permission.ManageOrders.Code) != null)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
