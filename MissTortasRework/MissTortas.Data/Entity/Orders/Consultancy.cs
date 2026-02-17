using MissTortas.Data.Entity.Products;

namespace MissTortas.Data.Entity.Orders
{
    public class Consultancy
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string BakeryNotes { get; set; } = string.Empty;
        public DateTime EstimatedFinishedTime { get; set; } = DateTime.Now;
        public DateTime AlternativeEstimatedFinishedTime { get; set; } = DateTime.Now;
        public virtual ConsultancyStatus Status { get; set; }
        public virtual ICollection<ConsultancyFile> ConsultancyFiles { get; set; } = [];
        public virtual ICollection<Order> Orders { get; set; } = [];
    }
}
