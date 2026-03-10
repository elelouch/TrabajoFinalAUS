using Microsoft.AspNetCore.Identity;

namespace MissTortas.Data.Entity.Security.User
{
    public class ApplicationUserToken : IdentityUserToken<long>
    {
        public virtual ApplicationUser User { get; set; } = null!;
    }
}
