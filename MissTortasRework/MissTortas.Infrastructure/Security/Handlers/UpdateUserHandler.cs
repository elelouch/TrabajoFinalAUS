using Microsoft.AspNetCore.Authorization;
using MissTortas.Infrastructure.Security.Permissions;
using MissTortas.Infrastructure.Security.Requirements;

namespace MissTortas.Infrastructure.Security.Handlers
{
    public class UpdateUserHandler : AuthorizationHandler<UpdateUserRequirement, UserModificationDTO>
    {
        protected async override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            UpdateUserRequirement requirement,
            UserModificationDTO userModification)
        {
            var currentUsername = context.User.Identity?.Name;
            var claimType = Permission.ClaimName;
            var updateAllValue = Permission.UpdateAllUser.Code;

            if (context.User.HasClaim(claimType, updateAllValue))
            {
                context.Succeed(requirement);
                return;
            }

            var updateSelfValue = Permission.UpdateSelfUser.Code;
            if (context.User.HasClaim(claimType, updateSelfValue) && currentUsername == userModification.Username)
            {
                if (userModification.IsEnabled == null && !userModification.Roles.Any())
                {
                    context.Succeed(requirement);
                    return;
                }

            }
        }
    }
}