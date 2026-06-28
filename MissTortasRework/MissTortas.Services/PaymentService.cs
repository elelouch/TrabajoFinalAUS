using MissTortas.Domain.Payments;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.DTO.Payment;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapping.Interfaces;

namespace MissTortas.Services
{
    public class PaymentService(
        IPaymentMapper paymentMapper,
        IOrderService orderService
        ) : IPaymentService
    {

        private static async Task<Payment> ExecutePaymentAsync(Payment payment)
        {
            var random = new Random();
            var paymentSucceeded = random.Next(0, 10) < 9;
            payment.PaymentStatus = paymentSucceeded ? PaymentStatus.Completed : PaymentStatus.Cancelled;
            await Task.Yield();
            return payment;
        }

        public async Task PayOrderAsync(PayOrderDTO dto)
        {
            var paymentRequest = new PaymentRequest() { OrderId = dto.OrderId };
            var payment = new Payment()
            {
                PaymentStatus = PaymentStatus.Pending,
                PaymentRequest = paymentRequest
            };
            await ExecutePaymentAsync(payment);

            if (payment.PaymentStatus != PaymentStatus.Completed)
            {
                throw new PaymentFailedException("Payment failed");
            }

            var placeOrderDTO = new PlaceOrderDTO { OrderId = dto.OrderId };
            await orderService.PlaceOrderAsync(placeOrderDTO);
        }

        public IEnumerable<PaymentMethodDTO> AllPaymentMethods() => Enum.GetValues<PaymentMethodEnum>().Select(pm => paymentMapper.PaymentMethodToDTO(pm));

    }
}
