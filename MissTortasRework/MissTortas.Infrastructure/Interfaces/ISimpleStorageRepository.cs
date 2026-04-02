using MissTortas.Domain.Orders;
using MissTortas.Domain.Products;
using MissTortas.Infrastructure.Entity.Orders

namespace MissTortas.Repository
{
    public interface ISimpleStorageRepository : IRepositoryCrud<ProductFile>
    {
        public Task InsertConsultancyFileAsync(ConsultancyFile);
    }
}
