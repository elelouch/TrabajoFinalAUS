using MissTortas.Domain.Payment;
using MissTortas.Services.DTO.Payment;
using MissTortas.Services.Mapper.Interfaces;


namespace MissTortas.Services.Mapper
{
    public class PaymentMapper : IPaymentMapper
    {
        public PaymentMethodDTO PaymentMethodToDTO(PaymentMethodEnum paymentMethod)
        {
            return new PaymentMethodDTO { Id = (long)paymentMethod, Name = paymentMethod.ToString() };
        }
    }
}
