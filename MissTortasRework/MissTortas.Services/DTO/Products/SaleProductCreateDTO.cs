namespace MissTortas.Services.DTO.Products
{
    public class SaleProductCreateDTO
    {
        public float SalePrice { get; set; }
        public long SaleQuantity { get; set; }
        public long ProductId { get; set; }
        public string SaleDescription { get; set; } = string.Empty;
        public string SaleImagePath { get; set; } = string.Empty;
    }
}
