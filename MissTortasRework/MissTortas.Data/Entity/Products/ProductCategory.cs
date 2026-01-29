namespace MissTortas.Data.Entity.Products
{
    public class ProductCategory : Category
    {
        public long Id { get; set; }
        public override required string Name { get; set; } = string.Empty;
        public required List<ProductCategory> Children { get; set; }
        public override required bool IsFinal { get; set; }
        public ProductCategory? Parent { get; set; }
        public required List<Product> Products { get; set; }
    }
}
