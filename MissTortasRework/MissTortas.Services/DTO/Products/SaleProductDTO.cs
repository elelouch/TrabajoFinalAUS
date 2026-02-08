using MissTortas.Data.Entity.Products;

namespace MissTortas.Services.DTO.Products
{
    public class SaleProductDTO
    {
        public long Id { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool AllowDecimalAsk { get; set; }
    }
}
