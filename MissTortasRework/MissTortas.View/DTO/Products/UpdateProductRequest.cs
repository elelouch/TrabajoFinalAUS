namespace MissTortas.View.DTO.Products
{
    public class UpdateProductRequest
    {
        public string? Description { get; set; }
        public long? CategoryId { get; set; }
        public decimal? Quantity { get; set; }
    }
}
