namespace MissTortas.View.DTO.Products
{
    public class UpdateSaleProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal QuantityAvailable { get; set; }
        public decimal Price { get; set; }
    }
}
