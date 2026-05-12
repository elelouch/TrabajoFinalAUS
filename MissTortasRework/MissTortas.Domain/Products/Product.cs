using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Domain.Products
{
    public class Product : IHasResource
    {
        public long ProductId { get; set; }
        public virtual Resource Resource { get; set; } = default!;
        public long ResourceId { get; set; } = default!;
        public string Name { get; set; } = string.Empty;
        public virtual ProductDetail ProductDetail { get; set; } = default!;
        public long ProductDetailId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; } = default!;
        public long ProductCategoryId { get; set; }
        public double Quantity { get; set; }
        public bool ManageQuantityAsInteger { get; set; }
        public string Unit { get; set; } = string.Empty;
    }
}
