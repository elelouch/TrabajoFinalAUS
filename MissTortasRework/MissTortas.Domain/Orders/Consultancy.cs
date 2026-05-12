using MissTortas.Domain.Security.Authorization;
using MissTortas.Domain.Security.Users;

namespace MissTortas.Domain.Orders
{
    public class Consultancy : IHasResource
    {
        public long ConsultancyId { get; set; }
        public virtual Resource Resource { get; set; } = default!;
        public long ResourceId { get; set; } = default!;
        public string Title { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string BakeryNotes { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public long AssigneeId { get; set; }
        public virtual required User Assignee { get; set; }
        public long ClientId { get; set; }
        public virtual required User Client { get; set; }
        public virtual ConsultancyStatus Status { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = [];
    }
}
