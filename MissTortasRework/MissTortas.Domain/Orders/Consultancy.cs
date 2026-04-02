using MissTortas.Domain.Security.Authorization;
using MissTortas.Domain.Security.Users;

namespace MissTortas.Domain.Orders
{
    public class Consultancy : Resource
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string BakeryNotes { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public virtual required User Assignee { get; set; }
        public virtual required User Client { get; set; }
        public virtual ConsultancyStatus Status { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = [];
    }
}
