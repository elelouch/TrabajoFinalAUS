namespace MissTortas.Services.DTO.Products
{
    public class UpdateProductDTO
    {
        public long ProductId { get; set; }
        public string? Description { get; set; } = string.Empty;
        public long? CategoryId { get; set; }
        public decimal? Quantity { get; set; }
    }
}
