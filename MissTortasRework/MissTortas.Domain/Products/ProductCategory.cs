namespace MissTortas.Domain.Products
{
    public class ProductCategory
    {
        public long ProductCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsFinal { get; set; }
        public virtual ICollection<ProductCategory> Children { get; set; } = [];
        public long? ParentId { get; set; }
        public virtual ProductCategory? Parent { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<Product> Products { get; set; } = [];
    }
}
