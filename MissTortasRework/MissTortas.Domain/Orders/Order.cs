using MissTortas.Domain.Payments;
using MissTortas.Domain.Products;
using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Domain.Orders
{
    public class Order : IHasResource
    {
        public long OrderId { get; set; }
        public virtual Resource Resource { get; set; } = default!;
        public long ResourceId { get; set; } = default!;
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
