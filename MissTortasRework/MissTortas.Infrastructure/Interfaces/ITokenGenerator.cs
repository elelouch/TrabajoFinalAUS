using System.Security.Claims;

namespace MissTortas.Infrastructure.Interfaces
{
    public interface ITokenGenerator
    {
        public string GenerateAccessToken(ClaimsPrincipal userPrincipal);
        public string GenerateRefreshToken(string userId);
    }
}
