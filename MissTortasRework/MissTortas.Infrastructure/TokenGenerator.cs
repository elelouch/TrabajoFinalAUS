using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MissTortas.Infrastructure.Configuration;
using MissTortas.Infrastructure.Interfaces;
using MissTortas.Infrastructure.Security.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;


namespace MissTortas.Infrastructure
{
    public class TokenGenerator(IOptions<JwtOptions> jwtOptions) : ITokenGenerator
    {
        public async Task<string> GenerateToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = "VerySecureSymmetricKeySaracatungueanos"u8.ToArray();

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            };

            var roleClaims = user.UserRoles
                .SelectMany(ur => ur.Role.RoleClaims)
                .Select(rc => rc.ToClaim());
            var userClaims = user.Claims.Select(userClaim => userClaim.ToClaim());
            var allClaims = roleClaims.Concat(userClaims).Distinct();

            claims.AddRange(allClaims);


            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
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
