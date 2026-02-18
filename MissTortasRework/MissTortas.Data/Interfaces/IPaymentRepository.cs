using MissTortas.Data.Entity.Payment;

namespace MissTortas.Data.Interfaces
{
    public interface IPaymentRepository : IRepositoryCrud<Payment>
    {
        public Task InsertPaymentMethodAsync(PaymentMethod paymentMethod);
        public IAsyncEnumerable<PaymentMethod> GetPaymentMethods();
    }
}
