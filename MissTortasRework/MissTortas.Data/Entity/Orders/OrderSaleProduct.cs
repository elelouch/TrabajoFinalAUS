using MissTortas.Data.Entity.Products;

namespace MissTortas.Data.Entity.Orders
{
    public class OrderSaleProduct
    {
        public long SaleProductId { get; set; }
        public long OrderId { get; set; }
        public double QuantityAsked { get; set; }
        public virtual required SaleProduct SaleProduct { get; set; }
        public virtual required Order Order { get; set; }
    }
}
