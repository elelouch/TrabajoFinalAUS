using Microsoft.AspNetCore.Mvc;
using MissTortas.Services.DTO.Payment;
using MissTortas.Services.Interfaces;



using CreatePaymentMethodServiceDTO = MissTortas.Services.DTO.Payment.CreatePaymentMethodDTO;
using CreatePaymentMethodDTO = MissTortas.Engine.DTO.Payment.CreatePaymentMethodDTO;
using PayOrderServiceDTO = MissTortas.Services.DTO.Payment.PayOrderDTO;
using PayOrderDTO = MissTortas.Engine.DTO.Payment.PayOrderDTO;

namespace MissTortas.Engine.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController(IPaymentService paymentService)
    {
        [HttpPost("method")]
        public async Task<ActionResult<PaymentMethodDTO>> PostPaymentType(CreatePaymentMethodDTO dto)
        {
            var serviceDto = new CreatePaymentMethodServiceDTO { Name = dto.Name };
            return await paymentService.CreatePaymentMethodAsync(serviceDto);
        }

        [HttpGet("method")]
        public async Task<ActionResult<IEnumerable<PaymentMethodDTO>>> GetPaymentTypes()
        {
            var ret = await paymentService.AllPaymentMethodsAsync();
            return ret.ToList();
        }

        [HttpPost("order")]
        public async Task<ActionResult> PostPayOrder(PayOrderDTO dto)
        {
            var serviceDto = new PayOrderServiceDTO
            {
                OrderId = dto.OrderId,
                CardHolderName = dto.CardHolderName,
                PaymentMethod = dto.PaymentMethod,
                ExpirationDate = dto.ExpirationDate,
                PAN = dto.PAN
            };
            paymentService.PayOrderAsync()
            return new EmptyResult();
        }
    }
}
