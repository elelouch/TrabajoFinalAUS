namespace MissTortas.View.DTO.Products
{
    public class UpdateSaleProductRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? QuantityAvailable { get; set; }
        public decimal? Price { get; set; }
    }
}
