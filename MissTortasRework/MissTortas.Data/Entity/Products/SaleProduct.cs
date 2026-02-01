namespace MissTortas.Data.Entity.Products
{
    public class SaleProduct
    {
        public long Id { get; set; }
        public required Product StockProduct { get; set; }
        public string SaleDescription { get; set; } = string.Empty;
        public double SalePrice { get; set; }
        public double SaleQuantity { get; set; }
        public string SaleImagePath { get; set; } = string.Empty;
    }
}
