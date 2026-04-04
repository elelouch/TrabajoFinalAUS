using MissTortas.Domain.Security.Authorization;
using MissTortas.Domain.Security.Users;

namespace MissTortas.Domain.Orders
{
    public class OrderPreparation : Resource
    {
        public long OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public long AssigneeId { get; set; }
        public User Assignee { get; set; } = null!;
        public bool Done { get; set; }
        public string Detail { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; }
        public DateTime FinalizationTime { get; set; }
    }
}
