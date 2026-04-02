using MissTortas.Domain.Payment;
using MissTortas.Domain.Products;
using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Domain.Orders
{
    public class Order : Resource
    {
        public long Id { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public virtual required OrderStatus OrderStatus { get; set; }
        public required OrderType OrderType;
        public virtual ICollection<OrderSaleProduct> ProductsAsked { get; set; } = [];
        public virtual ICollection<OrderPreparation> Preparations { get; set; } = [];
        public virtual ICollection<PersonalizedProduct> PersonalizedProducts { get; set; } = [];
        public virtual required Consultancy Consultancy { get; set; }
        public virtual PaymentRequest? PaymentRequest { get; set; }
    }
}
