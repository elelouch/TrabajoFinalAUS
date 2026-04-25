using MissTortas.Domain.Products;
using MissTortas.Infrastructure.Entity.Orders;
using MissTortas.Services.Repositories;

namespace MissTortas.Infrastructure.Interfaces
{
    public interface ISimpleStorageRepository : IRepositoryCrud<ProductFile>
    {
        public Task InsertConsultancyFileAsync(ConsultancyFile cf);
    }
}
