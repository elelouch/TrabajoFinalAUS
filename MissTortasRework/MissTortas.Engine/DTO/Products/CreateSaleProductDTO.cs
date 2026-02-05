namespace MissTortas.Engine.DTO.Products
{
    public class CreateSaleProductDTO
    {
        public double SalePrice { get; set; }
        public double SaleQuantity { get; set; }
        public long SaleQuantityUnit { get; set; }
        public long StockProductId { get; set; }
        public bool IsAvailable { get; set; }
        public string SaleDescription { get; set; } = string.Empty;
    }
}
