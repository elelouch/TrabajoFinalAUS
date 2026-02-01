using MissTortas.Data.Entity.Security;

namespace MissTortas.Data.Entity.Orders
{
    public class Order
    {
        public long Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public required OrderStatus OrderStatus { get; set; }
        public required OrderType OrderType;
        public required ApplicationUser OrderManager { get; set; }
        public required ApplicationUser Client { get; set; }
        public ICollection<OrderSaleProduct> ProductsAsked { get; set; } = [];
        public ICollection<OrderPreparation> Preparations { get; set; } = [];
        public Consultancy? Consultancy { get; set; }
    }
}
