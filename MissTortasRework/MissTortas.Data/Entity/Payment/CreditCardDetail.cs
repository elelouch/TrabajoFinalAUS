namespace MissTortas.Data.Entity.Payment
{
    public class CreditCardDetail : PaymentMethodDetailBase
    {
        public required string PAN { get; set; } = string.Empty;
        public required string ExpirationDate { get; set; } = string.Empty;
        public required string CardHolderName { get; set; } = string.Empty;
    }
}
