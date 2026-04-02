using MissTortas.Domain.Payments;

namespace MissTortas.Domain.Repositories
{
    public interface IPaymentRepository : IRepositoryCrud<Payment>
    {
        public Task InsertPaymentMethodDetailAsync(PaymentMethodDetail paymentMethod);
        public IAsyncEnumerable<PaymentMethodDetail> GetPaymentMethods();
    }
}
