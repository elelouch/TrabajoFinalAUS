namespace MissTortas.View.DTO.Products
{
    public class CreateSaleProduct
    {
        public double SalePrice { get; set; }
        public double SaleQuantity { get; set; }
        public long StockProductId { get; set; }
        public bool IsAvailable { get; set; }
        public string SaleDescription { get; set; } = string.Empty;
    }
}
