using MissTortas.Domain.Payments;
using MissTortas.Services.DTO.Payment;
using MissTortas.Services.Mapping.Interfaces;


namespace MissTortas.Services.Mapping
{
    public class PaymentMapper : IPaymentMapper
    {
        public PaymentMethodDTO PaymentMethodToDTO(PaymentMethodEnum paymentMethod)
        {
            return new PaymentMethodDTO { Id = (long)paymentMethod, Name = paymentMethod.ToString() };
        }
    }
}
