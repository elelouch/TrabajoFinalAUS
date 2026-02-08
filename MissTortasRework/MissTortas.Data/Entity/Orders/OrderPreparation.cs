using MissTortas.Data.Entity.Security;

namespace MissTortas.Data.Entity.Orders
{
    public class OrderPreparation
    {
        public long Id { get; set; }
        public required Order Order { get; set; }
        public required ApplicationUser Assignee { get; set; }
        public bool Done { get; set; }
        public string Detail { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; }
        public DateTime FinalizationTime { get; set; }
    }
}
