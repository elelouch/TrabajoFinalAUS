using MissTortas.Domain.Orders;

namespace MissTortas.Domain.Payments
{
    public class PaymentRequest
    {
        public long Id { get; set; }
        public DateTime RequestTime { get; set; } = DateTime.Now;
        public virtual Payment? Payment { get; set; }
        public long OrderId { get; set; }
        public virtual required Order Order { get; set; }
    }
}
