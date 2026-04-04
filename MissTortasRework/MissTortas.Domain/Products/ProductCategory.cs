namespace MissTortas.Domain.Products
{
    public class ProductCategory : Category
    {
        public virtual ICollection<Product> Products { get; set; } = [];
    }
}
