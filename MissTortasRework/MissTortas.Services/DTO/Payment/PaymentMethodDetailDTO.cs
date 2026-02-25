namespace MissTortas.Services.DTO.Payment
{
    public class PaymentMethodDetailDTO
    {
        public string CardHolderName { get; set; } = string.Empty;
        public string PAN { get; set; } = string.Empty;
        public string ExpirationDate { get; set; } = string.Empty;
        public bool StorePaymentDetails { get; set; }
    }
}
