using MissTortas.Data.Entity.Security.Permissions;
using MissTortas.Presentation.DTO.Security;
using MissTortas.Services.DTO.Security;
using System.Security.Claims;

namespace MissTortas.Presentation.Mappers
{
    public class UserMapper : IUserMapper
    {
        public CurrentUserDTO UserToCurrentUserDTO(ClaimsPrincipal user)
        {
            var currentUser = new CurrentUserDTO
            {
                Id = long.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!),
                Username = user.Identity!.Name ?? "",
                Permissions = [.. user.FindAll(Permission.ClaimName).Select(c => c.Value)],
                Roles = [.. user.FindAll(ClaimTypes.Role).Select(c => c.Value)]
            };
            return currentUser;
        }
    }
}
