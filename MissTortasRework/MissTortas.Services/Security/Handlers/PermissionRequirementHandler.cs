using Microsoft.AspNetCore.Authorization;
using MissTortas.Services.Security.Requirements;

namespace MissTortas.Services.Security.Handlers
{
    public class PermissionRequirementHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User.HasClaim(requirement.ClaimType, requirement.ClaimValue))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
