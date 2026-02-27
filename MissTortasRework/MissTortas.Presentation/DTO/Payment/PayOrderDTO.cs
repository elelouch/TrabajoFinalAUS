namespace MissTortas.Presentation.DTO.Payment
{
    public class PayOrderDTO
    {
        public required long OrderId { get; set; }
        public required int PaymentMethod { get; set; }
        public PaymentMethodDetailDTO? PaymentDetails { get; set; }
    }
}
