using MissTortas.Data.Entity.Payment;
using MissTortas.Services.DTO.Payment;


namespace MissTortas.Services.Mapper
{
    public class PaymentMapper : IPaymentMapper
    {
        public PaymentMethodDTO PaymentMethodToDTO(PaymentMethodEnum paymentMethod)
        {
            return new PaymentMethodDTO { Id = (long)paymentMethod, Name = paymentMethod.ToString()};
        }
    }
}
