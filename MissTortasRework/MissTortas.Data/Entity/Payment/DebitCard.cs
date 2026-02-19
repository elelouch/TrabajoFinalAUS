namespace MissTortas.Data.Entity.Payment
{
    public class DebitCard : PaymentMethodDetailBase
    {
        public string PAN { get; set; } = string.Empty;
        public string ExpirationDate { get; set; } = string.Empty;
        public string CardHolderName { get; set; } = string.Empty;
    }
}
