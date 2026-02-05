namespace MissTortas.Data.Entity.Products
{
    public class SaleProduct
    {
        public long Id { get; set; }
        public virtual required Product StockProduct { get; set; }
        public string SaleDescription { get; set; } = string.Empty;
        public double SalePrice { get; set; }
        public double SaleQuantityDecimal { get; set; }
        public long SaleQuantityUnit { get; set; }
        public bool AllowDecimalAsk { get; set; }
        public string SaleImagePath { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
    }
}
