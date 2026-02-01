using MissTortas.Data.Entity.Products;

namespace MissTortas.Data.Entity.Orders
{
    public class OrderSaleProduct
    {
        public double QuantityAsked { get; set; }
        public required SaleProduct SaleProduct { get; set; }
        public required Order Order { get; set; }
    }
}
