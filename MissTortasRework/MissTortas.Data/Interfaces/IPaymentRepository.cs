using MissTortas.Data.Entity.Payment;

namespace MissTortas.Data.Interfaces
{
    public interface IPaymentRepository : IRepositoryCrud<Payment>
    {
        public Task InsertPaymentMethodDetailAsync(PaymentMethodDetailBase paymentMethod);
        public IAsyncEnumerable<PaymentMethodDetailBase> GetPaymentMethods();
    }
}
