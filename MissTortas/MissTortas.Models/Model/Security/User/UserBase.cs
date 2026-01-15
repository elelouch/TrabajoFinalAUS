using Microsoft.AspNetCore.Identity;
using MissTortas.Models.Model.Security.Permissions;

namespace MissTortas.Models.Model.Security.User
{
    public class UserBase : IdentityUser<long>
    {
        public string Password { get; set; } = string.Empty;
        public List<Role>? Roles { get; set; }
    }
}
