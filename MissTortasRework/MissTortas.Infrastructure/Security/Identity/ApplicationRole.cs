using Microsoft.AspNetCore.Identity;
using MissTortas.Domain.Security.Users;

namespace MissTortas.Infrastructure.Security.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public long RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}
