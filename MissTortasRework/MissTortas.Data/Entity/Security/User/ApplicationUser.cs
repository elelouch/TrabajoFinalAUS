using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Orders;

namespace MissTortas.Data.Entity.Security.User
{
    public class ApplicationUser : IdentityUser<long>
    {
        public Guid Guid { get; set; }
        public virtual ICollection<OrderPreparation> Preparations { get; set; } = [];
        public IEnumerable<Permission> Permissions { get; set; } = [];
    }
}
