using MissTortas.Domain.Payments;
using MissTortas.Infrastructure.Context;
using MissTortas.Services.Repositories;

namespace MissTortas.Infrastructure.Repositories
{
    public class PaymentRepository(MissTortasContext context) : RepositoryCrud<Payment>(context), IPaymentRepository
    {
    }
}
