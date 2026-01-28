namespace MissTortas.Engine.DTO.Products
{
    public class CreateSaleProductDTO
    {
        public float SalePrice { get; set; }
        public long SaleQuantity { get; set; }
        public long ProductId { get; set; }
        public string SaleDescription { get; set; } = string.Empty;
    }
}
