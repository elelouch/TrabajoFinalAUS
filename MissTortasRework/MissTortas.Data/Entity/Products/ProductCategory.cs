namespace MissTortas.Data.Entity.Products
{
    public class ProductCategory : Category
    {
        public long Id { get; set; }
        public override required string Name { get; set; } = string.Empty;
        public List<ProductCategory> Children { get; set; } = [];
        public override required bool IsFinal { get; set; }
        public ProductCategory? Parent { get; set; }
        public List<Product> Products { get; set; } = [];
    }
}
