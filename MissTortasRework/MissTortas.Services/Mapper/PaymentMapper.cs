using MissTortas.Data.Entity.Payment;
using MissTortas.Services.DTO.Payment;


namespace MissTortas.Services.Mapper
{
    public class PaymentMapper : IPaymentMapper
    {
        public PaymentMethodDTO PaymentMethodToDTO(PaymentMethod paymentMethod)
        {
            return new PaymentMethodDTO
            {
                Id = paymentMethod.Id,
                Name = paymentMethod.Name
            };
        }
    }
}
