namespace MissTortas.View.DTO.Payment
{
    public class PaymentMethodDetail
    {
        public string CardHolderName { get; set; } = string.Empty;
        public string PAN { get; set; } = string.Empty;
        public string ExpirationDate { get; set; } = string.Empty;
        public bool StorePaymentDetails { get; set; }
    }
}
