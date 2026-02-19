namespace MissTortas.Data.Entity.Payment
{
    public class PaymentRequest
    {
        public long Id { get; set; }
        public DateTime RequestTime { get; set; } = DateTime.Now;
        public virtual Payment? Payment { get; set; }
    }
}
