using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Requirements;
using MissTortas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MissTortas.Infrastructure.Security.Handlers
{
    public class ManageAssignedPreparationHandler(UserManager<ApplicationUser> userManager) : AuthorizationHandler<ManageAssignedPreparationRequirement, long>
    {
        protected async override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            ManageAssignedPreparationRequirement requirement,
            long orderPreparationId
            )
        {
            var claim = context.User.FindFirst(JwtRegisteredClaimNames.Sub) ?? throw new InvalidOperationException("Token must have sub claim");
            var userId = claim.Value;
            var userHasPreparation = await userManager.Users
                .AnyAsync(u => u.Id == userId && u.User.Preparations.Any(p => p.OrderPreparationId == orderPreparationId));
            if(userHasPreparation)
            {
                context.Succeed(requirement);
            }
        }
    }
}
