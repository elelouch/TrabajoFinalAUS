using Microsoft.AspNetCore.Mvc;
using MissTortas.Services.DTO.Payment;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using PayOrder = MissTortas.View.DTO.Payment.PayOrder;
using PayOrderServiceDTO = MissTortas.Services.DTO.Payment.PayOrderDTO;

namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentsController(IPaymentService paymentService) : ControllerBase
    {
        [HttpGet("method")]
        public async Task<IEnumerable<PaymentMethodDTO>> GetPaymentMethods()
        {
            return paymentService.AllPaymentMethods();
        }

        [HttpPost("order")]
        public async Task<ActionResult> PostPayOrder(PayOrder dto)
        {
            var serviceDto = new PayOrderServiceDTO
            {
                OrderId = dto.OrderId,
                PaymentMethod = dto.PaymentMethod,
            };
            await paymentService.PayOrderAsync(serviceDto);
            return new EmptyResult();
        }
    }
}
