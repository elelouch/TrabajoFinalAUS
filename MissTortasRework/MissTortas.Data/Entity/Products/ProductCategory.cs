namespace MissTortas.Data.Entity.Products
{
    public class ProductCategory : Category
    {
        public long Id { get; set; }
        public override required string Name { get; set; } = string.Empty;
        public virtual ICollection<ProductCategory> Children { get; set; } = [];
        public override required bool IsFinal { get; set; }
        public virtual ProductCategory? Parent { get; set; }
        public virtual ICollection<Product> Products { get; set; } = [];
    }
}
