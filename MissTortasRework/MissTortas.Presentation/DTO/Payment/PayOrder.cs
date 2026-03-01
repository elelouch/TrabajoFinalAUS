namespace MissTortas.Presentation.DTO.Payment
{
    public class PayOrder
    {
        public required long OrderId { get; set; }
        public required int PaymentMethod { get; set; }
        public PaymentMethodDetail? PaymentDetails { get; set; }
    }
}
