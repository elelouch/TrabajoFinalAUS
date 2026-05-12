using MissTortas.Domain.Products;
using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Domain.Orders
{
    public class OrderSaleProduct : IHasResource
    {
        public long OrderSaleProductId { get; set; }
        public Resource Resource { get; set; } = default!;
        public long ResourceId { get; set; }
        public long OrderId { get; set; }
        public double QuantityAsked { get; set; }
        public long SaleProductId { get; set; }
        public virtual SaleProduct SaleProduct { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
