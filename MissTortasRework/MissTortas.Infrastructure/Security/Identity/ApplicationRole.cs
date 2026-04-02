using Microsoft.AspNetCore.Identity;

namespace MissTortas.Infrastructure.Security.Identity
{
    public class ApplicationRole : IdentityRole<long>
    {
        public DateTime LastTimeModified { get; set; }
        public bool Deleted { get; set; }
        public bool Trivial { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = [];
        public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; } = [];

        public static ApplicationRole AdminRole { get; set; } = new() { Name = "Admin", NormalizedName = "ADMIN" };
        public static ApplicationRole UserRole { get; set; } = new() { Name = "User", NormalizedName = "USER" };
    }
}
