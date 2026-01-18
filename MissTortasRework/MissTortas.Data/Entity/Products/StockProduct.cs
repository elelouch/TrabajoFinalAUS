namespace MissTortas.Data.Entity.Products
{
    public class StockProduct : Product
    {
        public required ProductImage StockImage { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
    }
}
