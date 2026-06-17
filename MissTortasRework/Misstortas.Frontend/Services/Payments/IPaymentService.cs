namespace Misstortas.Frontend.Services.Payments
{
    public interface IPaymentService
    {
        Task<PaymentMethodDTO[]> GetPaymentMethodsAsync();
        Task PayOrderAsync(PayOrderDTO payOrder);
    }
}