using Microsoft.AspNetCore.Identity;

namespace MissTortas.Infrastructure.Security.Identity
{
    public class ApplicationRoleClaim : IdentityRoleClaim<long>
    {
        public virtual ApplicationRole Role { get; set; } = null!;
    }
}
