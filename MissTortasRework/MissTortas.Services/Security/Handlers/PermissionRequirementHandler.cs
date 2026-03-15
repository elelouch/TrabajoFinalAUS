using Microsoft.AspNetCore.Authorization;
using MissTortas.Services.Security.Requirements;
using System.Security.Claims;

namespace MissTortas.Services.Security.Handlers
{
    public class PermissionRequirementHandler
        : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            PermissionRequirement requirement)
        {
            foreach (var claim in requirement.ClaimsRequired)
            {
                if (!context.User.HasClaim(claim.Type, claim.Value))
                {
                    return Task.CompletedTask;
                }
            } 
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}