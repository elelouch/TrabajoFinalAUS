using Microsoft.AspNetCore.Identity;

namespace MissTortas.Data.Entity.Security.User
{
    public class ApplicationUserRole : IdentityUserRole<long>
    {
        public virtual ApplicationUser User { get; set; } = null!;
        public virtual ApplicationRole Role { get; set; } = null!;
    }
}
