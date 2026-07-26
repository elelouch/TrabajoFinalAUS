using System.Security.Claims;

namespace MissTortas.Infrastructure.Interfaces
{
    public interface ITokenGenerator
    {
        public string GenerateAccessToken(ClaimsPrincipal userPrincipal);
        public Task<string> GenerateRefreshToken(string userId);
        public Task<string?> ValidateRefreshTokenAsync(string refreshToken);
        Task SaveRefreshTokenAsync(string userId, string refreshToken);
        Task RevokeRefreshTokenAsync(string refreshToken);
    }
}
