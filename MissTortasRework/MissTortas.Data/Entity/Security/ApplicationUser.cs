using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Orders;

namespace MissTortas.Data.Entity.Security
{
    public class ApplicationUser : IdentityUser<long>
    {
        public Guid Guid { get; set; }
        public virtual required ICollection<OrderPreparation> Preparations { get; set; } = [];
    }
}
