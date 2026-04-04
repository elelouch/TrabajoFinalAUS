using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Domain.Payments
{
    public class Payment : Resource
    {
        public DateTime DateTime { get; set; } = DateTime.Now;
        public virtual PaymentMethodDetail? PaymentMethodDetail { get; set; }
        public long PaymentRequestId { get; set; }
        public virtual PaymentRequest PaymentRequest { get; set; } = null!;
        public virtual PaymentStatus PaymentStatus { get; set; }
    }
}
