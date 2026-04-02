using MissTortas.Domain.Products;
using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Domain.Orders
{
    public class OrderSaleProduct : Resource
    {
        public long SaleProductId { get; set; }
        public long OrderId { get; set; }
        public double QuantityAsked { get; set; }
        public virtual required SaleProduct SaleProduct { get; set; }
        public virtual required Order Order { get; set; }
    }
}
