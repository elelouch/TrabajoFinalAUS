namespace MissTortas.Domain.Products
{
    public partial class SaleProduct
    {
        public long Id { get; set; }
        public virtual required Product StockProduct { get; set; }
        public string SaleDescription { get; set; } = string.Empty;
        public double SalePrice { get; set; }
        public double SaleQuantity { get; set; }
        public string SaleImagePath { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } // used to help whether to show up on a view or modify the view, the quantity can be 0 and the product still be available to view
    }
}
