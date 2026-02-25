using Microsoft.AspNetCore.Authorization;
using MissTortas.Data.Interfaces;
using MissTortas.Services.Security.Requirement;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MissTortas.Services.Security.Handler
{
    public class ViewUserRequirementHandler (ISecurityRepository securityRepository): AuthorizationHandler<ViewUserRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, ViewUserRequirement requirement)
        {
            var userIdString = context.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("User must have a Name Identifier Claim.");
            var userId = long.Parse(userIdString);
            var permission = securityRepository.UserHasViewPermission(userId, requirement.ViewUserPermission);

            if(permission is not null)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
