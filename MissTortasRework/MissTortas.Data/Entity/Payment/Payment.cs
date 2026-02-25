namespace MissTortas.Data.Entity.Payment
{
    public class Payment
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public virtual PaymentMethodDetailBase? PaymentMethodDetail { get; set; }
        public long PaymentRequestId { get; set; }
        public virtual required PaymentRequest PaymentRequest { get; set; }
        public required PaymentStatus PaymentStatus { get; set; }
    }
}
