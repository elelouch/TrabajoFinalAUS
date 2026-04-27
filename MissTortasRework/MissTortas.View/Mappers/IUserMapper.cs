using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Services;
using MissTortas.View.DTO.Security;
using System.Security.Claims;

namespace MissTortas.View.Mappers
{
    public interface IUserMapper
    {
        public CurrentUserDTO UserToCurrentUserDTO(ClaimsPrincipal user);
        public UserMetadata UserContextToUserMetadata(UserContext user);
    }
}
