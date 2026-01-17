using Microsoft.AspNetCore.Identity;
using MissTortas.Models.Security.Permissions;

namespace MissTortas.Models.Security.User
{
    public class UserBase : IdentityUser<long>
    {
        public string Password { get; set; } = string.Empty;
        public List<Role>? Roles { get; set; }
    }
}
