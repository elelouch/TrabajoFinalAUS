using MissTortas.Domain.Products;

namespace MissTortas.Infrastructure.Entity.Products
{
    public class ProductFile
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string Extension { get; set; } = string.Empty;
        public long ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public string Path { get; set; } = string.Empty;
    }
}
