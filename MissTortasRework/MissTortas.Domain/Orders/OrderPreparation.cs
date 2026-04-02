using MissTortas.Domain.Security.Authorization;
using MissTortas.Domain.Security.Users;

namespace MissTortas.Domain.Orders
{
    public class OrderPreparation : Resource
    {
        public long Id { get; set; }
        public required Order Order { get; set; }
        public required User Assignee { get; set; }
        public bool Done { get; set; }
        public string Detail { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; }
        public DateTime FinalizationTime { get; set; }
    }
}
