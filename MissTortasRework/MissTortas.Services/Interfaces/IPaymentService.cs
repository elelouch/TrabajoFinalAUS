using MissTortas.Services.DTO.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Interfaces
{
    public interface IPaymentService
    {
        public Task<PaymentMethodDTO> CreatePaymentMethodAsync(CreatePaymentMethodDTO dto);
        public Task<IEnumerable<PaymentMethodDTO>> AllPaymentMethodsAsync();
        public Task<IEnumerable<PaymentMethodDTO>> PayOrderAsync();
    }
}
