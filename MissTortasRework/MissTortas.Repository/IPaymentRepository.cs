using MissTortas.Domain.Payment;

namespace MissTortas.Repository
{
    public interface IPaymentRepository : IRepositoryCrud<Payment>
    {
        public Task InsertPaymentMethodDetailAsync(PaymentMethodDetail paymentMethod);
        public IAsyncEnumerable<PaymentMethodDetail> GetPaymentMethods();
    }
}
