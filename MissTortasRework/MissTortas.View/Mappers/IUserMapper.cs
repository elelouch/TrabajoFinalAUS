using MissTortas.Infrastructure.DTO.Security;
using System.Security.Claims;

namespace MissTortas.View.Mappers
{
    public interface IUserMapper
    {
        public CurrentUserDTO UserToCurrentUserDTO(ClaimsPrincipal user);
    }
}
