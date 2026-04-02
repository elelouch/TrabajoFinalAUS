using Microsoft.AspNetCore.Identity;

namespace MissTortas.Infrastructure.Security.Identity
{
    public class ApplicationUserLogin : IdentityUserLogin<long>
    {
        public virtual ApplicationUser User { get; set; } = null!;

    }
}
