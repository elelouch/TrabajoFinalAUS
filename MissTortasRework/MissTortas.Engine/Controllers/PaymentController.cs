using Microsoft.AspNetCore.Mvc;
using MissTortas.Services.DTO.Payment;


using CreatePaymentMethodServiceDTO = MissTortas.Services.DTO.Payment.CreatePaymentMethodDTO;
using CreatePaymentMethodDTO = MissTortas.Engine.DTO.Payment.CreatePaymentMethodDTO;
using MissTortas.Services.Interfaces;

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
    }
}
