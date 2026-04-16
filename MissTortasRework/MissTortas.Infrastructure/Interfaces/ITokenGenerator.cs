using System.Security.Claims;

namespace MissTortas.Infrastructure.Interfaces
{
    public interface ITokenGenerator
    {
        public Task<string> GenerateToken(ClaimsPrincipal userPrincipal);
    }
}
