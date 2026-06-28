using MissTortas.Infrastructure.DTO.Security;
using System.Security.Claims;

namespace MissTortas.Infrastructure.Mappings.Interfaces
{
    public interface IUserMapper
    {
        public UserMetadata ClaimsPrincipalToUserMetadata(ClaimsPrincipal principal);
    }
}
