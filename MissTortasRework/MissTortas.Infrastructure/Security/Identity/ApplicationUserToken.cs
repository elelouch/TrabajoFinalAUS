using Microsoft.AspNetCore.Identity;

namespace MissTortas.Infrastructure.Security.Identity
{
    public class ApplicationUserToken : IdentityUserToken<long>
    {
        public virtual ApplicationUser User { get; set; } = null!;
    }
}
