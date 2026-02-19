namespace MissTortas.Data.Entity.Payment
{
    public class PaymentMethodDetailBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Payment> Payments { get; set; } = [];
    }
}
