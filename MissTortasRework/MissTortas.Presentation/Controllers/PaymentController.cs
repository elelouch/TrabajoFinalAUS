using Microsoft.AspNetCore.Mvc;
using MissTortas.Services.DTO.Payment;
using MissTortas.Services.Interfaces;


using CreatePaymentMethodDTO = MissTortas.Presentation.DTO.Payment.CreatePaymentMethod;
using PaymentMethodDetailsServiceDTO = MissTortas.Services.DTO.Payment.PaymentMethodDetailDTO;
using PaymentMethodDetailsDTO = MissTortas.Presentation.DTO.Payment.PaymentMethodDetail;
using PayOrderServiceDTO = MissTortas.Services.DTO.Payment.PayOrderDTO;
using PayOrder = MissTortas.Presentation.DTO.Payment.PayOrder;

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
        public async Task<ActionResult> PostPayOrder(PayOrder dto)
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
