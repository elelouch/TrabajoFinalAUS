using MissTortas.Domain.Products;
using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Domain.Orders
{
    public class OrderSaleProduct : Resource
    {
        public long OrderId { get; set; }
        public double QuantityAsked { get; set; }
        public long SaleProductId { get; set; }
        public virtual SaleProduct SaleProduct { get; set; } = null!;
        public virtual required Order Order { get; set; }
    }
}
