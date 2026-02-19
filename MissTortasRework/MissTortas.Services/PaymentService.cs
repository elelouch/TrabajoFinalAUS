using MissTortas.Data.Entity.Payment;
using MissTortas.Data.Interfaces;
using MissTortas.Services.DTO.Payment;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapper;

namespace MissTortas.Services
{
    public class PaymentService (
        IPaymentRepository paymentRepository,
        IPaymentMapper paymentMapper
        ) : IPaymentService
    {
        public async Task<PaymentMethodDTO> CreatePaymentMethodAsync(CreatePaymentMethodDTO dto)
        {
            var paymentMethod = new PaymentMethodDetailBase { Name = dto.Name };
            await paymentRepository.InsertPaymentMethodAsync(paymentMethod);
            await paymentRepository.SaveChangesAsync();
            return paymentMapper.PaymentMethodToDTO(paymentMethod);
        }

        public async Task<IEnumerable<PaymentMethodDTO>> AllPaymentMethodsAsync()
        {
            var paymentMethods = paymentRepository.GetPaymentMethods();
            return await paymentMethods.Select(pm => paymentMapper.PaymentMethodToDTO(pm)).ToListAsync();
        }

    }
}
