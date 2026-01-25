namespace MissTortas.Data.Entity.Products
{
    public class ProductDetail
    {
        public long Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public Product? Product { get; set; }
    }
}
