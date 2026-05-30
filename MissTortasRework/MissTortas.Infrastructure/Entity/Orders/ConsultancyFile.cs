using MissTortas.Domain.Orders;

namespace MissTortas.Infrastructure.Entity.Orders
{
    public class ConsultancyFile
    {
        public long Id { get; set; }
        public long ConsultancyId { get; set; }
        public Consultancy Consultancy { get; set; } = default!;
        public string Path { get; set; } = string.Empty;
    }
}
