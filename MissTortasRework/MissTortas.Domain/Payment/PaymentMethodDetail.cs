namespace MissTortas.Domain.Payment
{
    public abstract class PaymentMethodDetail
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual required Payment Payment { get; set; }
        public long PaymentId { get; set; }
    }
}
