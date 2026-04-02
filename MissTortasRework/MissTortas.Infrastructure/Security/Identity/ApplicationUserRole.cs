using Microsoft.AspNetCore.Identity;

namespace MissTortas.Infrastructure.Security.Identity
{
    public class ApplicationUserRole : IdentityUserRole<long>
    {
        public virtual ApplicationUser User { get; set; } = null!;
        public virtual ApplicationRole Role { get; set; } = null!;
    }
}
