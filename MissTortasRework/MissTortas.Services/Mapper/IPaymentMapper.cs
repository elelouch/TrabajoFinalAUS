using MissTortas.Data.Entity.Payment;
using MissTortas.Services.DTO.Payment;


namespace MissTortas.Services.Mapper
{
    public interface IPaymentMapper
    {
        public PaymentMethodDTO PaymentMethodToDTO(PaymentMethodEnum paymentMethod);
    }
}
