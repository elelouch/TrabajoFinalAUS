using MissTortas.Infrastructure.Security.Permissions;

namespace MissTortas.View.DTO.Security
{
    public class UserDTO
    {
        public IEnumerable<Permission> Permissions { get; set; } = [];
    }
}
