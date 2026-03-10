using Microsoft.AspNetCore.Identity;

namespace MissTortas.Data.Entity.Security.User
{
    public class ApplicationUserClaim : IdentityUserClaim<long>
    {
        public virtual ApplicationUser User { get; set; } = null!;
    }
}
