namespace MissTortas.Data.Entity.Products
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual required ProductDetail ProductDetail { get; set; }
        public virtual required ProductCategory ProductCategory { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
    }
}
