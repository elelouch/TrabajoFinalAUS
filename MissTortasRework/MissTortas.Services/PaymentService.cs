using MissTortas.Services.DTO.Payment;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Exceptions;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.Mapper.Interfaces;
using MissTortas.Domain.Payment;
using MissTortas.Repository;

namespace MissTortas.Services
{
    public class PaymentService(
        IPaymentRepository paymentRepository,
        IPaymentMapper paymentMapper,
        IOrderService orderService
        ) : IPaymentService
    {
        private static PaymentMethodDetail GetPaymentMethodDetail(
            PayOrderDTO dto,
            Payment payment
            )
        {
            if (!Enum.IsDefined(typeof(PaymentMethodEnum), dto.PaymentMethod))
            {
                throw new InvalidOperationException("Invalid payment method specified");
            }
            var pm = dto.PaymentDetails is null ? PaymentMethodEnum.Cash : (PaymentMethodEnum)dto.PaymentMethod;
            return pm switch
            {
                PaymentMethodEnum.DebitCard => new DebitCardDetail
                {
                    Payment = payment,
                    PAN = dto.PaymentDetails!.PAN,
                    CardHolderName = dto.PaymentDetails!.CardHolderName,
                    ExpirationDate = dto.PaymentDetails!.ExpirationDate
                },
                PaymentMethodEnum.CreditCard => new CreditCardDetail
                {
                    Payment = payment,
                    PAN = dto.PaymentDetails!.PAN,
                    CardHolderName = dto.PaymentDetails!.CardHolderName,
                    ExpirationDate = dto.PaymentDetails!.ExpirationDate
                },
                PaymentMethodEnum.Cash => new CashDetail() { Payment = payment },
                _ => throw new InvalidOperationException("Invalid payment method specified"),
            };
        }

        private static async Task<Payment> ExecutePaymentAsync(Payment payment)
        {
            if (payment.PaymentMethodDetail is null)
            {
                return payment;
            }
            var random = new Random();
            var paymentSucceeded = random.Next(0, 10) < 9;
            payment.PaymentStatus = paymentSucceeded ? PaymentStatus.Completed : PaymentStatus.Cancelled;
            await Task.Yield();
            return payment;
        }

        public async Task PayOrderAsync(PayOrderDTO dto)
        {
            var order = await orderService.GetOrderEntityAsync(dto.OrderId);
            var paymentRequest = new PaymentRequest() { Order = order };
            var payment = new Payment()
            {
                PaymentStatus = PaymentStatus.Pending,
                PaymentRequest = paymentRequest
            };

            var paymentMethodDetail = GetPaymentMethodDetail(dto, payment);
            await ExecutePaymentAsync(payment);

            if (payment.PaymentStatus != PaymentStatus.Completed && paymentMethodDetail is not CashDetail)
            {
                throw new PaymentFailedException("Payment failed");
            }

            await paymentRepository.InsertAsync(payment);
            var storePaymentDetails = dto.PaymentDetails is not null && dto.PaymentDetails.StorePaymentDetails;
            if (storePaymentDetails)
            {
                await paymentRepository.InsertPaymentMethodDetailAsync(paymentMethodDetail);
            }
            await paymentRepository.SaveChangesAsync();

            var placeOrderDTO = new PlaceOrderDTO { OrderId = order.Id };
            await orderService.PlaceOrderAsync(placeOrderDTO);
        }

        public IEnumerable<PaymentMethodDTO> AllPaymentMethods() => Enum.GetValues<PaymentMethodEnum>().Select(pm => paymentMapper.PaymentMethodToDTO(pm));

    }
}
