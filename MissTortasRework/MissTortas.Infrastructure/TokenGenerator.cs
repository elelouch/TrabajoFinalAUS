using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MissTortas.Infrastructure.Configuration;
using MissTortas.Infrastructure.Interfaces;
using MissTortas.Infrastructure.Security.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;


namespace MissTortas.Infrastructure
{
    public class TokenGenerator(
        IOptions<JwtOptions> jwtOptions,
        RoleManager<ApplicationRole> roleManager,
        UserManager<ApplicationUser> userManager
    ) : ITokenGenerator
    {
        public async Task<string> GenerateToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(jwtOptions.Value.Key);

            var tokenClaims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, user.Id),
            };

            var roleIds = user.User.Roles.Select(role => role.Id);
            
            var allUserClaims = new HashSet<(string type, string value)>();
            var roles = roleManager.Roles.Where(appRole => roleIds.Contains(appRole.RoleId)).ToAsyncEnumerable();
            await foreach (var role in roles)
            {
                var roleClaims = await roleManager.GetClaimsAsync(role);
                foreach (var claim in roleClaims)
                {
                    allUserClaims.Add((claim.ValueType, claim.Value));
                }
            }
            var userClaims = (await userManager.GetClaimsAsync(user));
            foreach (var userClaim in userClaims)
            {
                allUserClaims.Add((userClaim.ValueType, userClaim.Value));
            }

            tokenClaims.AddRange(allUserClaims.Select(c => new Claim(c.type, c.value)));


            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(tokenClaims),
                Expires = DateTime.UtcNow.AddMinutes(jwtOptions.Value.ExpirationMinutes),
                Issuer = jwtOptions.Value.Issuer,
                Audience = jwtOptions.Value.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
