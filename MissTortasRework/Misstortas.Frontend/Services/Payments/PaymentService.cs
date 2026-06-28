using Misstortas.Frontend.Services.Shared;

namespace Misstortas.Frontend.Services.Payments
{
    public class PaymentService(IMissTortasClient missTortasClient) : IPaymentService
    {
        public async Task<PaymentMethodDTO[]> GetPaymentMethodsAsync()
        {
            try
            {
                var result = await missTortasClient.GetAsync<PaymentMethodDTO[]>("/payments/method");
                return result ?? [];
            }
            catch (HttpRequestException)
            {
                return [];
            }
        }

        public async Task PayOrderAsync(PayOrderDTO payOrder)
        {
            await missTortasClient.PostAsync<object>("/payments/order", payOrder);
        }
    }
}