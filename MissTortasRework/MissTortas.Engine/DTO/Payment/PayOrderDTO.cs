namespace MissTortas.Engine.DTO.Payment
{
    public class PayOrderDTO
    {
        public long OrderId { get; set; }
        public int PaymentMethod { get; set; }
        public string CardHolderName { get; set; } = string.Empty;
        public string PAN { get; set; } = string.Empty;
        public string ExpirationDate { get; set; } = string.Empty;
    }
}
