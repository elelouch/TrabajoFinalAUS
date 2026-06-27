using MissTortas.Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Text;

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
