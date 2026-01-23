using Microsoft.AspNetCore.Identity;

namespace MissTortas.Data.Entity.Security
{
    public class User : IdentityUser<long>
    {
        public required Guid Guid;
        public List<Role>? Roles { get; set; }
    }
}
