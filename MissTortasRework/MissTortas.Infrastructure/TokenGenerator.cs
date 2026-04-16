using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MissTortas.Infrastructure.Configuration;
using MissTortas.Infrastructure.Interfaces;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Permissions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;


namespace MissTortas.Infrastructure
{
    public class TokenGenerator(
        IOptions<JwtOptions> jwtOptions
    ) : ITokenGenerator
    {
        public async Task<string> GenerateToken(ApplicationUser user, IEnumerable<Claim> userClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(jwtOptions.Value.Key);

            var tokenClaims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, user.Id)
            };

            tokenClaims.AddRange(userClaims.Where(c => c.Type == Permission.ClaimName));


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

        public async Task<string> GenerateToken(ClaimsPrincipal userPrincipal)
        {
            var userId = userPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                throw new InvalidOperationException("The userPrincipal does not contain a valid NameIdentifier claim.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(jwtOptions.Value.Key);

            var tokenClaims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, userId)
            };

            tokenClaims.AddRange(userPrincipal.Claims.Where(c => c.Type == Permission.ClaimName));

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
