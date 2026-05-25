
namespace MissTortas.Domain.Payments
{
    public class Payment
    {
        public long PaymentId { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public long PaymentRequestId { get; set; }
        public virtual PaymentRequest PaymentRequest { get; set; } = null!;
        public virtual PaymentStatus PaymentStatus { get; set; }
    }
}
