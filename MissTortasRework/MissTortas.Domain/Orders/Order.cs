using MissTortas.Domain.Payments;
using MissTortas.Domain.Products;

namespace MissTortas.Domain.Orders
{
    public class Order
    {
        public long OrderId { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public virtual required OrderStatus OrderStatus { get; set; }
        public required OrderType OrderType;
        public virtual ICollection<OrderSaleProduct> ProductsAsked { get; set; } = [];
        public virtual ICollection<OrderPreparation> Preparations { get; set; } = [];
        public virtual ICollection<PersonalizedProduct> PersonalizedProducts { get; set; } = [];
        public long ConsultancyId { get; set; }
        public virtual Consultancy Consultancy { get; set; } = null!;
        public long PaymenRequestId { get; set; }
        public virtual PaymentRequest? PaymentRequest { get; set; }
    }
}
