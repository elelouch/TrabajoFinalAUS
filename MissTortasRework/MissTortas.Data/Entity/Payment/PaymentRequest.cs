namespace MissTortas.Data.Entity.Payment
{
    public class PaymentRequest
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public required Payment Payment { get; set; }
    }
}
