namespace MissTortas.Data.Entity.Products
{
    public class ProductDetail
    {
        public long Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public virtual Product? Product { get; set; }
    }
}
