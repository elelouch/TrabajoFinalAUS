using MissTortas.Data.Entity.Security;

namespace MissTortas.Data.Entity.Orders
{
    public class Order
    {
        public long Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public virtual required OrderStatus OrderStatus { get; set; }
        public required OrderType OrderType;
        public virtual required ApplicationUser OrderManager { get; set; }
        public required ApplicationUser Client { get; set; }
        public virtual ICollection<OrderSaleProduct> ProductsAsked { get; set; } = [];
        public virtual ICollection<OrderPreparation> Preparations { get; set; } = [];
        public virtual Consultancy? Consultancy { get; set; }
    }
}
