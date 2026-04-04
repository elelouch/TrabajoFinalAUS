using MissTortas.Domain.Orders;
using MissTortas.Domain.Products;
using MissTortas.Domain.Repositories;
using MissTortas.Infrastructure.Entity.Orders;

namespace MissTortas.Infrastructure.Interfaces
{
    public interface ISimpleStorageRepository : IRepositoryCrud<ProductFile>
    {
        public Task InsertConsultancyFileAsync(ConsultancyFile cf);
    }
}
