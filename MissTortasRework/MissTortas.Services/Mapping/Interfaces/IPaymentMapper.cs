using MissTortas.Domain.Payments;
using MissTortas.Services.DTO.Payment;


namespace MissTortas.Services.Mapping.Interfaces
{
    public interface IPaymentMapper
    {
        public PaymentMethodDTO PaymentMethodToDTO(PaymentMethodEnum paymentMethod);
    }
}
