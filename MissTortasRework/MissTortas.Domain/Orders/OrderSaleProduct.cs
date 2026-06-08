using MissTortas.Domain.Products;

namespace MissTortas.Domain.Orders
{
    public class OrderSaleProduct
    {
        public long OrderSaleProductId { get; set; }
        public long OrderId { get; set; }
        public decimal QuantityAsked { get; set; }
        public long SaleProductId { get; set; }
        public virtual SaleProduct SaleProduct { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
