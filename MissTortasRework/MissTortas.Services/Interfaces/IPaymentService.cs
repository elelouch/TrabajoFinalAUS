using MissTortas.Services.DTO.Payment;

namespace MissTortas.Services.Interfaces
{
    public interface IPaymentService
    {
        public IEnumerable<PaymentMethodDTO> AllPaymentMethods();
        public Task PayOrderAsync(PayOrderDTO dto);
    }
}
