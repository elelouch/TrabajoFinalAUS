using Microsoft.AspNetCore.Identity;

namespace MissTortas.Infrastructure.Security.Identity
{
    public class ApplicationUserClaim : IdentityUserClaim<long>
    {
        public virtual ApplicationUser User { get; set; } = null!;
    }
}
