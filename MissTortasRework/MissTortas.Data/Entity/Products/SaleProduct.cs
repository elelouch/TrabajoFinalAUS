namespace MissTortas.Data.Entity.Products
{
    public class SaleProduct
    {
        public required Product StockProduct { get; set; }
        public required string SaleImagePath { get; set; }
    }
}
