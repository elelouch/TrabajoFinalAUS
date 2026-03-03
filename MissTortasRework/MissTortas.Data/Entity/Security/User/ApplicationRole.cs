using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Security.Permissions;

namespace MissTortas.Data.Entity.Security.User
{
    public class ApplicationRole: IdentityRole<long>
    {
        public DateTime LastTimeModified { get; set; }
        public bool Deleted { get; set; }
        public bool Trivial { get; set; }
        public virtual List<Permission> Permissions { get; set; } = [];
        public virtual List<ApplicationUser> Users { get; set; } = [];

        public static ApplicationRole AdminRole { get; set; } = new() { Name = "Admin", NormalizedName = "ADMIN"};
        public static ApplicationRole UserRole { get; set; } = new() { Name = "User", NormalizedName = "USER" };
    }
}
