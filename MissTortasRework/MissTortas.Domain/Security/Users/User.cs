using MissTortas.Domain.Orders;

namespace MissTortas.Domain.Security.Users
{
    public class User
    {
        public long UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly Birthday { get; set; }
        public virtual ICollection<OrderPreparation> Preparations { get; set; } = [];
        public virtual ICollection<Role> Roles { get; set; } = [];
    }
}
