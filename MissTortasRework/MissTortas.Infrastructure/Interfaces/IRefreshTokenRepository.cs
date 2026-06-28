using MissTortas.Infrastructure.Entity;

namespace MissTortas.Infrastructure.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshTokenEntity> GetRefreshTokenAsync(string token);
        Task AddRefreshTokenAsync(RefreshTokenEntity refreshToken);
        Task RevokeRefreshTokenAsync(string token);
        Task RevokeAllUserRefreshTokensAsync(string userId);
        Task DeleteExpiredTokensAsync();
    }
}
