namespace MissTortas.Domain.Payment
{
    public class DebitCardDetail : PaymentMethodDetail
    {
        public required string PAN { get; set; } = string.Empty;
        public required string ExpirationDate { get; set; } = string.Empty;
        public required string CardHolderName { get; set; } = string.Empty;
    }
}
