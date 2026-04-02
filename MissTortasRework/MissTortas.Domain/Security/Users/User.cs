using MissTortas.Domain.Orders;
using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Domain.Security.Users
{
    public class User : Subject
    {
        public long Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public DateOnly Birthday { get; set; }
        public virtual ICollection<OrderPreparation> Preparations { get; set; } = [];
    }
}
