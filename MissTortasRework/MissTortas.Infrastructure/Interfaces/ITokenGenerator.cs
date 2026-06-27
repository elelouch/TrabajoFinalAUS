using System.Security.Claims;

namespace MissTortas.Infrastructure.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateAccessToken(ClaimsPrincipal userPrincipal);
        string GenerateRefreshToken(string userId);
        Task<string> ValidateRefreshTokenAsync(string refreshToken);
        Task SaveRefreshTokenAsync(string userId, string refreshToken);
        Task RevokeRefreshTokenAsync(string refreshToken);
    }
}
