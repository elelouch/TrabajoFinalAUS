using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Entity.Security.Permissions;

namespace MissTortas.Data.Entity.Security.User
{
    public class ApplicationUser : IdentityUser<long>
    {
        public Guid Guid { get; set; }
        public virtual ICollection<OrderPreparation> Preparations { get; set; } = [];
        public virtual ICollection<ApplicationUserClaim> Claims { get; set; } = null!;
        public virtual ICollection<ApplicationUserLogin> Logins { get; set; } = null!;
        public virtual ICollection<ApplicationUserToken> Tokens { get; set; } = null!;
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = [];
    }
}
