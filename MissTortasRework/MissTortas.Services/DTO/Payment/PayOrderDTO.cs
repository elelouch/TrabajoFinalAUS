namespace MissTortas.Services.DTO.Payment
{
    public class PayOrderDTO
    {
        public long OrderId { get; set; }
        public int PaymentMethod { get; set; }
        public PaymentMethodDetailDTO? PaymentDetails { get; set; }
    }
}
