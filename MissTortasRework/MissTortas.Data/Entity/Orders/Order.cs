using MissTortas.Data.Entity.Products;
using MissTortas.Data.Entity.Security;

namespace MissTortas.Data.Entity.Orders
{
    public class Order
    {
        public long Id { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public virtual required OrderStatus OrderStatus { get; set; }
        public OrderType? OrderType;
        public virtual ICollection<OrderSaleProduct> ProductsAsked { get; set; } = [];
        public virtual ICollection<OrderPreparation> Preparations { get; set; } = [];
        public virtual ICollection<PersonalizedProduct> PersonalizedProducts { get; set; } = [];
        public virtual required Consultancy Consultancy { get; set; }
    }
}
