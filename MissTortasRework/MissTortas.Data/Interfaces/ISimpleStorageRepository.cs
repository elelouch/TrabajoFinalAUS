using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Entity.Products;

namespace MissTortas.Data.Interfaces
{
    public interface ISimpleStorageRepository : IRepositoryCrud<ProductFile>
    {
        public Task InsertConsultancyFileAsync(ConsultancyFile cf);
    }
}
