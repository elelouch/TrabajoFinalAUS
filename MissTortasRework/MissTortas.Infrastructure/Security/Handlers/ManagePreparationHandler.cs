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
            if(context.User.HasClaim(Permission.ClaimName, Permission.ManageOrders.Code))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            if (context.User.HasClaim(Permission.ClaimName, Permission.ReadPreparations.Code) && requirement.Operation == PreparationOperationEnum.Read)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }
    }
}
