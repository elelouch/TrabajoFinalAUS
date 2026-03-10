using Microsoft.AspNetCore.Identity;

namespace MissTortas.Data.Entity.Security.User
{
    public class ApplicationRoleClaim : IdentityRoleClaim<long>
    {
        public virtual ApplicationRole Role { get; set; } = null!;
    }
}
