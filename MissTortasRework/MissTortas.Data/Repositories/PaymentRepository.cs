using Microsoft.EntityFrameworkCore;
using MissTortas.Data.Context;
using MissTortas.Data.Entity.Payment;
using MissTortas.Data.Interfaces;

namespace MissTortas.Data.Repositories
{
    public class PaymentRepository(MissTortasContext context) : RepositoryCrud<Payment>(context), IPaymentRepository
    {
        private readonly DbSet<PaymentMethod> paymentMethods = context.PaymentMethods;
        public async Task InsertPaymentMethodAsync(PaymentMethod paymentMethod)
        {
            await paymentMethods.AddAsync(paymentMethod);
        }

        public IAsyncEnumerable<PaymentMethod> GetPaymentMethods()
        {
            return paymentMethods.ToAsyncEnumerable();
        }
    }
}
