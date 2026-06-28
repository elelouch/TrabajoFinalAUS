using Microsoft.EntityFrameworkCore;
using MissTortas.Infrastructure.Context;
using MissTortas.Infrastructure.Entity;
using MissTortas.Infrastructure.Interfaces;

namespace MissTortas.Infrastructure.Security
{
    public class RefreshTokenRepository(MissTortasContext context) : IRefreshTokenRepository
    {
        public async Task<RefreshTokenEntity> GetRefreshTokenAsync(string token)
        {
            return await context.RefreshTokens.FirstAsync(rt => rt.Token == token);
        }

        public async Task AddRefreshTokenAsync(RefreshTokenEntity refreshToken)
        {
            refreshToken.CreatedAt = DateTime.UtcNow;
            context.RefreshTokens.Add(refreshToken);
            await context.SaveChangesAsync();
        }

        public async Task RevokeRefreshTokenAsync(string token)
        {
            var refreshToken = await GetRefreshTokenAsync(token);
            if (refreshToken != null)
            {
                refreshToken.IsRevoked = true;
                context.RefreshTokens.Update(refreshToken);
                await context.SaveChangesAsync();
            }
        }

        public async Task RevokeAllUserRefreshTokensAsync(string userId)
        {
            var tokens = await context.RefreshTokens
                .Where(rt => rt.UserId == userId && !rt.IsRevoked)
                .ToListAsync();

            foreach (var token in tokens)
            {
                token.IsRevoked = true;
            }

            context.RefreshTokens.UpdateRange(tokens);
            await context.SaveChangesAsync();
        }

        public async Task DeleteExpiredTokensAsync()
        {
            var expiredTokens = await context.RefreshTokens
                .Where(rt => rt.ExpiresAt < DateTime.UtcNow)
                .ToListAsync();

            context.RefreshTokens.RemoveRange(expiredTokens);
            await context.SaveChangesAsync();
        }
    }
}
