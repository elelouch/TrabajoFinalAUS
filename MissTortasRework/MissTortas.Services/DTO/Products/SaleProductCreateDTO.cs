namespace MissTortas.Services.DTO.Products
{
    public class SaleProductCreateDTO
    {
        public double SalePrice { get; set; }
        public double Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public long ProductId { get; set; }
        public string SaleDescription { get; set; } = string.Empty;
        public string SaleImagePath { get; set; } = string.Empty;
    }
}
