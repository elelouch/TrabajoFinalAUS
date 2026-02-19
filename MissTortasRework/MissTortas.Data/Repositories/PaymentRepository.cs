using Microsoft.EntityFrameworkCore;
using MissTortas.Data.Context;
using MissTortas.Data.Entity.Payment;
using MissTortas.Data.Interfaces;

namespace MissTortas.Data.Repositories
{
    public class PaymentRepository(MissTortasContext context) : RepositoryCrud<Payment>(context), IPaymentRepository
    {
        private readonly DbSet<PaymentMethodDetailBase> paymentMethods = context.PaymentMethodDetails;
        public async Task InsertPaymentMethodAsync(PaymentMethodDetailBase paymentMethod)
        {
            await paymentMethods.AddAsync(paymentMethod);
        }

        public IAsyncEnumerable<PaymentMethodDetailBase> GetPaymentMethods()
        {
            return paymentMethods.ToAsyncEnumerable();
        }
    }
}
