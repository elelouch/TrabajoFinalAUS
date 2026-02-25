using MissTortas.Services.DTO.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Interfaces
{
    public interface IPaymentService
    {
        public IEnumerable<PaymentMethodDTO> AllPaymentMethods();
        public Task PayOrderAsync(PayOrderDTO dto);
    }
}
