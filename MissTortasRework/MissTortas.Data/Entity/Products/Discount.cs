namespace MissTortas.Data.Entity.Products
{
    public class Discount
    {
        public int Percentage { get; set; }
        public float Quantity { get; set; }
        public string Reason { get; set; } = string.Empty;
        public required SaleProduct SaleProduct { get; set; }
    }
}
