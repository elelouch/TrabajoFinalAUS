namespace MissTortas.View.DTO.Orders
{
    public class SaleProductAskedResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal QuantityAsked { get; set; }
        public decimal Price { get; set; }
    }
}