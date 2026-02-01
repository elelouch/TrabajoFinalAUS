using MissTortas.Data.Entity.Security;

namespace MissTortas.Data.Entity.Orders
{
    public class Order
    {
        public long Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public required OrderType OrderType;
        public required ApplicationUser OrderManager { get; set; }
        public required ApplicationUser Client { get; set; }
        public required ICollection<OrderSaleProduct> ProductsSold { get; set; }
        public required ICollection<OrderPreparation> Preparations { get; set; }
        public Consultancy? Consultancy { get; set; }
    }
}
