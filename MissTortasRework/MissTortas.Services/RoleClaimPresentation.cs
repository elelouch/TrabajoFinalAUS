using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Security.User;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MissTortas.Services
{
    public class RoleClaimsTransformation : IClaimsTransformation
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleClaimsTransformation(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identity = (ClaimsIdentity)principal.Identity!;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId != null)
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    foreach (var roleName in roles)
                    {
                        var role = await _roleManager.FindByNameAsync(roleName);
                        if (role != null)
                        {
                            var roleClaims = await _roleManager.GetClaimsAsync(role);
                            foreach (var claim in roleClaims)
                            {
                                if (!identity.HasClaim(claim.Type, claim.Value))
                                {
                                    identity.AddClaim(claim);
                                }
                            }
                        }
                    }
                }
            }

            return principal;
        }
    }
}
