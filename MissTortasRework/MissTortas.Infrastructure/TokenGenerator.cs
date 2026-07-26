using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MissTortas.Infrastructure.Configuration;
using MissTortas.Infrastructure.Entity;
using MissTortas.Infrastructure.Interfaces;
using MissTortas.Infrastructure.Security.Permissions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;


namespace MissTortas.Infrastructure
{
    public class TokenGenerator(
        IOptions<JwtOptions> jwtOptions,
        IRefreshTokenRepository refreshTokenRepository
    ) : ITokenGenerator
    {
        public string GenerateAccessToken(ClaimsPrincipal userPrincipal)
        {
            var userId = userPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            if (jwtOptions?.Value == null)
            {
                throw new InvalidOperationException("JWT options are not configured.");
            }
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
                Expires = DateTime.UtcNow.AddMinutes(jwtOptions.Value.ExpirationMinutesAccessToken),
                Issuer = jwtOptions.Value.Issuer,
                Audience = jwtOptions.Value.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<string> GenerateRefreshToken(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new InvalidOperationException("The userPrincipal does not contain a valid NameIdentifier claim.");
            }
            if (jwtOptions?.Value == null)
            {
                throw new InvalidOperationException("JWT options are not configured.");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(jwtOptions.Value.Key);

            var tokenClaims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, userId)
            };

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(tokenClaims),
                Expires = DateTime.UtcNow.AddMinutes(jwtOptions.Value.ExpirationMinutesRefreshToken),
                Issuer = jwtOptions.Value.Issuer,
                Audience = jwtOptions.Value.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenStr =  tokenHandler.WriteToken(token);
            await SaveRefreshTokenAsync(userId, tokenStr);
            return tokenStr;
        }
        public async Task<string?> ValidateRefreshTokenAsync(string refreshToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(jwtOptions.Value.Key);

                var principal = tokenHandler.ValidateToken(refreshToken, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions.Value.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtOptions.Value.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                // Check if token exists in database and hasn't been revoked
                var storedToken = await refreshTokenRepository.GetRefreshTokenAsync(refreshToken);
                if (storedToken == null || storedToken.IsRevoked)
                {
                    return null;
                }
                await RevokeRefreshTokenAsync(storedToken.Token!);
                // Extract userId from token
                var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
                return userId;
            }
            catch
            {
                return null;
            }
        }

        public async Task SaveRefreshTokenAsync(string userId, string refreshToken)
        {
            await refreshTokenRepository.AddRefreshTokenAsync(new RefreshTokenEntity
            {
                Token = refreshToken,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddMinutes(jwtOptions.Value.ExpirationMinutesRefreshToken),
                IsRevoked = false
            });
        }

        public async Task RevokeRefreshTokenAsync(string refreshToken)
        {
            await refreshTokenRepository.RevokeRefreshTokenAsync(refreshToken);
        }

    }
}
