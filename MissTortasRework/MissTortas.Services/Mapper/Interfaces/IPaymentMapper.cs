using MissTortas.Domain.Payment;
using MissTortas.Services.DTO.Payment;


namespace MissTortas.Services.Mapper.Interfaces
{
    public interface IPaymentMapper
    {
        public PaymentMethodDTO PaymentMethodToDTO(PaymentMethodEnum paymentMethod);
    }
}
