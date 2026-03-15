using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Security.User;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MissTortas.Services
{
    public class RoleClaimsTransformation(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager) : IClaimsTransformation
    {

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identity = (ClaimsIdentity)principal.Identity!;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null) return principal;

            var user = await userManager.FindByIdAsync(userId);
            if (user == null) return principal;

            var roles = await userManager.GetRolesAsync(user);
            foreach (var roleName in roles)
            {
                var role = await roleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    var roleClaims = await roleManager.GetClaimsAsync(role);
                    foreach (var claim in roleClaims)
                    {
                        if (!identity.HasClaim(claim.Type, claim.Value))
                        {
                            identity.AddClaim(claim);
                        }
                    }
                }
            }
            return principal;
        }
    }
}
