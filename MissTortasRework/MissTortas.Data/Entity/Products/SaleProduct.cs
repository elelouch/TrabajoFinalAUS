namespace MissTortas.Data.Entity.Products
{
    public partial class SaleProduct
    {
        public long Id { get; set; }
        public virtual required Product StockProduct { get; set; }
        public string SaleDescription { get; set; } = string.Empty;
        public double SalePrice { get; set; }
        public double SaleQuantity { get; set; }
        public double SaleQuantityInteger { get; set; }
        public string SaleImagePath { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
    }
}
