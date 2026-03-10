using Microsoft.AspNetCore.Identity;

namespace MissTortas.Data.Entity.Security.User
{
    public class ApplicationUserLogin : IdentityUserLogin<long>
    {
        public virtual ApplicationUser User { get; set; } = null!;

    }
}
