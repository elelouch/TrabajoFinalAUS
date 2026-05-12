using MissTortas.Domain.Orders;
using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Domain.Security.Users
{
    public class User
    {
        public long UserId { get; set; }
        public long SubjectId { get; set; }
        public Subject Subject { get; set; } = default!;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly Birthday { get; set; }
        public virtual ICollection<OrderPreparation> Preparations { get; set; } = [];
        public virtual ICollection<Role> Roles { get; set; } = [];
    }
}
