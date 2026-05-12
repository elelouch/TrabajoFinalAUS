using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Domain.Products
{
    public class ProductFile : IHasResource
    {
        public long Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string Extension { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public required Product Product { get; set; }
        public long ResourceId { get; set; }
        public Resource Resource { get; set; } = default!;
    }
}
