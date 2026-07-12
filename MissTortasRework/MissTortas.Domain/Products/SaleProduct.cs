namespace MissTortas.Domain.Products
{
    public class SaleProduct
    {
        public long SaleProductId { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public decimal SaleQuantity { get; set; }
        public decimal SalePrice { get; set; }
        public bool IsAvailable { get; set; }
    }
}
