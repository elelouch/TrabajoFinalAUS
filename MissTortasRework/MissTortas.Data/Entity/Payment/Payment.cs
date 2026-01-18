namespace MissTortas.Data.Entity.Payment
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public required PaymentMethod PaymentMethod { get; set; }
        public required PaymentRequest PaymentRequest { get; set; }
        public required string PaymentStatus { get; set; }
    }
}
