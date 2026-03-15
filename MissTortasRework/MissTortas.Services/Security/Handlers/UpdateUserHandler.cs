using Microsoft.AspNetCore.Authorization;
using MissTortas.Services.DTO.Security;
using MissTortas.Services.Security.Constants;
using MissTortas.Services.Security.Requirements;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Security.Handlers
{
    public class UpdateUserHandler
        : AuthorizationHandler<UpdateUserRequirement, UserModificationDTO>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            UpdateUserRequirement requirement,
            UserModificationDTO userModification)
        {
            var currentUsername = context.User.Identity?.Name;

            if (context.User.HasClaim(cl => cl.Equals(ClaimConstants.UpdateAllUser)))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            var userCanUpdateHimself = context.User.HasClaim(cl => cl.Equals(ClaimConstants.UpdateSelfUser))
                && currentUsername == userModification.Username;

            var hasNoStatusOrRoleChanges = userModification.IsEnabled == null && !userModification.Roles.Any();

            if (userCanUpdateHimself && hasNoStatusOrRoleChanges)
            {
                context.Succeed(requirement);
            }
            
            return Task.CompletedTask;
        }
    }
}
