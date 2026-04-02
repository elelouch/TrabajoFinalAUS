using MissTortas.Domain.Orders;
using MissTortas.Domain.Products;

namespace MissTortas.Repository
{
    public interface ISimpleStorageRepository : IRepositoryCrud<ProductFile>
    {
        public Task InsertConsultancyFileAsync(ConsultancyFile cf);
    }
}
