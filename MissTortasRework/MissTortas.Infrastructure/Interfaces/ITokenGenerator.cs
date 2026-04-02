using MissTortas.Infrastructure.Security.Identity;

namespace MissTortas.Infrastructure.Interfaces
{
    public interface ITokenGenerator
    {
        public Task<string> GenerateToken(ApplicationUser user);
    }
}
