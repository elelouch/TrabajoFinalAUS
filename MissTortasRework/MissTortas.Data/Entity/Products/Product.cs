namespace MissTortas.Data.Entity.Products
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public required ProductDetail ProductDetail { get; set; }
        public required ProductCategory ProductCategory { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
    }
}
