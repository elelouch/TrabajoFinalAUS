namespace MissTortas.Services.DTO.Products
{
    public class SaleProductCreateDTO
    {
        public double SalePrice { get; set; }
        public double SaleQuantityDecimal { get; set; }
        public long SaleQuantityUnits { get; set; }
        public bool UseDecimal { get; set; }
        public bool IsAvailable { get; set; }
        public long ProductId { get; set; }
        public string SaleDescription { get; set; } = string.Empty;
        public string SaleImagePath { get; set; } = string.Empty;
    }
}
