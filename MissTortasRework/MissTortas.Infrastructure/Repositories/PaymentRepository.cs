using Microsoft.EntityFrameworkCore;
using MissTortas.Domain.Payments;
using MissTortas.Infrastructure.Context;
using MissTortas.Services.Repositories;

namespace MissTortas.Infrastructure.Repositories
{
    public class PaymentRepository(MissTortasContext context) : RepositoryCrud<Payment>(context), IPaymentRepository
    {
        private readonly DbSet<PaymentMethodDetail> paymentMethods = context.PaymentMethodDetails;
        public async Task InsertPaymentMethodDetailAsync(PaymentMethodDetail paymentMethod)
        {
            await paymentMethods.AddAsync(paymentMethod);
        }

        public IAsyncEnumerable<PaymentMethodDetail> GetPaymentMethods()
        {
            return paymentMethods.ToAsyncEnumerable();
        }
    }
}
