using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Infrastructure.Security.Permissions;
using MissTortas.Services;
using MissTortas.View.DTO.Security;
using System.Security.Claims;

namespace MissTortas.View.Mappers
{
    public class UserMapper : IUserMapper
    {
        public UserMetadata UserContextToUserMetadata(UserContext user)
        {
            return new UserMetadata
            {
                UserId = user.UserId,
                AppUserId = user.AppUserId,
                Roles = user.Roles as List<string> ?? [],
                Capabilities = PermissionToCapabilities(user.Permissions)
            };
        }

        private static UserCapabilities PermissionToCapabilities(IEnumerable<string> permissions)
        {
            var permissionSet = new HashSet<string>(permissions);
            return new UserCapabilities
            {
                CanViewUsers = permissionSet.Any(p => p == Permission.ReadAllUser.Code)
            };
        }

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
