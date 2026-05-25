namespace MissTortas.Domain.Products
{
    public partial class SaleProduct
    {
        public long SaleProductId { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public double SaleQuantity { get; set; }
        public double SalePrice { get; set; }
        public bool IsAvailable { get; set; }
    }
}
