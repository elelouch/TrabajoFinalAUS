using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Domain.Payments
{
    public class Payment : Resource
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public virtual PaymentMethodDetail? PaymentMethodDetail { get; set; }
        public long PaymentRequestId { get; set; }
        public virtual required PaymentRequest PaymentRequest { get; set; }
        public required PaymentStatus PaymentStatus { get; set; }
    }
}
