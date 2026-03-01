namespace MissTortas.Presentation.DTO.Products
{
    public class UpdateProduct
    {
        public string Description { get; set; } = string.Empty;
        public long CategoryId { get; set; }
        public double Quantity { get; set; }
    }
}
