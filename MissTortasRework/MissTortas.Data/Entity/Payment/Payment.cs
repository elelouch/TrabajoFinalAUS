namespace MissTortas.Data.Entity.Payment
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public virtual required PaymentMethodDetailBase PaymentMethodDetail { get; set; }
        public long PaymentRequestId { get; set; }
        public virtual required PaymentRequest PaymentRequest { get; set; }
        public required string PaymentStatus { get; set; }
    }
}
