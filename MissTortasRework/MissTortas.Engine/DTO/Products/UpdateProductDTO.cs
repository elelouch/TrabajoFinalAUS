namespace MissTortas.Engine.DTO.Products
{
    public class UpdateProductDTO
    {
        public string Description { get; set; } = string.Empty;
        public long CategoryId { get; set; }
        public double Quantity { get; set; }
    }
}
