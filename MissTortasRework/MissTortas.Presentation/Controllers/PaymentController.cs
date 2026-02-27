using Microsoft.AspNetCore.Mvc;
using MissTortas.Services.DTO.Payment;
using MissTortas.Services.Interfaces;



//using CreatePaymentMethodServiceDTO = MissTortas.Services.DTO.Payment.CreatePaymentMethodDTO;
using CreatePaymentMethodDTO = MissTortas.Presentation.DTO.Payment.CreatePaymentMethodDTO;
using PaymentMethodDetailsServiceDTO = MissTortas.Services.DTO.Payment.PaymentMethodDetailDTO;
using PaymentMethodDetailsDTO = MissTortas.Presentation.DTO.Payment.PaymentMethodDetailDTO;
using PayOrderServiceDTO = MissTortas.Services.DTO.Payment.PayOrderDTO;
using PayOrderDTO = MissTortas.Presentation.DTO.Payment.PayOrderDTO;

namespace MissTortas.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController(IPaymentService paymentService) : Controller
    {
        [HttpGet("method")]
        public async Task<IEnumerable<PaymentMethodDTO>> GetPaymentMethods()
        {
            return paymentService.AllPaymentMethods();
        }

        [HttpPost("order")]
        public async Task<ActionResult> PostPayOrder(PayOrderDTO dto)
        {
            PaymentMethodDetailsServiceDTO? paymentMethodDetails = null;
            if (dto.PaymentDetails is not null)
            {
                paymentMethodDetails = new PaymentMethodDetailsServiceDTO
                {
                    ExpirationDate = dto.PaymentDetails.ExpirationDate,
                    PAN = dto.PaymentDetails.PAN,
                    StorePaymentDetails = dto.PaymentDetails.StorePaymentDetails,
                    CardHolderName = dto.PaymentDetails.CardHolderName
                };
            }
            var serviceDto = new PayOrderServiceDTO
            {
                OrderId = dto.OrderId,
                PaymentMethod = dto.PaymentMethod,
                PaymentDetails = paymentMethodDetails
            };
            await paymentService.PayOrderAsync(serviceDto);
            return new EmptyResult();
        }
    }
}
