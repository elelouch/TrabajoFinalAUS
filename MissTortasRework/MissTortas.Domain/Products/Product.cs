namespace MissTortas.Domain.Products
{
    public class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual ProductDetail ProductDetail { get; set; } = default!;
        public long ProductDetailId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; } = default!;
        public long ProductCategoryId { get; set; }
        public decimal Quantity { get; set; }
        public bool ManageQuantityAsInteger { get; set; }
        public string Unit { get; set; } = string.Empty;
    }
}
