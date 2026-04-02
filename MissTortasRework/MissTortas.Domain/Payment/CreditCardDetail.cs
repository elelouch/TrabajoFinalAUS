namespace MissTortas.Domain.Payment
{
    public class CreditCardDetail : PaymentMethodDetail
    {
        public required string PAN { get; set; } = string.Empty;
        public required string ExpirationDate { get; set; } = string.Empty;
        public required string CardHolderName { get; set; } = string.Empty;
    }
}
