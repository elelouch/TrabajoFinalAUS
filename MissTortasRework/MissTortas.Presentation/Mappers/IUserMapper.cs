using MissTortas.Infrastructure.DTO.Security;
using System.Security.Claims;

namespace MissTortas.Presentation.Mappers
{
    public interface IUserMapper
    {
        public CurrentUserDTO UserToCurrentUserDTO(ClaimsPrincipal user);
    }
}
