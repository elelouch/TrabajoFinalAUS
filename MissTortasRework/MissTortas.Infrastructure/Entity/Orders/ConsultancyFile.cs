using MissTortas.Domain.Orders;

namespace MissTortas.Infrastructure.Entity.Orders
{
    public class ConsultancyFile
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string Extension { get; set; } = string.Empty;
        public long ConsultancyId { get; set; }
        public Consultancy Consultancy { get; set; }
        public string Path { get; set; } = string.Empty;
    }
}
