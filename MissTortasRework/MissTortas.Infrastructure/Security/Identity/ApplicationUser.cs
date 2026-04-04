using Microsoft.AspNetCore.Identity;
using MissTortas.Domain.Security.Users;

namespace MissTortas.Infrastructure.Security.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public User User { get; set; } = null!;
        public required long UserId { get; set; }
    }
}
