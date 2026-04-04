using MissTortas.Domain.Orders;
using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Domain.Security.Users
{
    public class User : Subject
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly Birthday { get; set; }
        public virtual ICollection<OrderPreparation> Preparations { get; set; } = [];
        public virtual ICollection<Role> Roles { get; set; } = [];
    }
}
