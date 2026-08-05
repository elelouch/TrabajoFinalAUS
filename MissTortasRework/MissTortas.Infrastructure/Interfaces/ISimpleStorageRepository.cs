using MissTortas.Infrastructure.Entity.Orders;
using MissTortas.Infrastructure.Entity.Products;
using MissTortas.Services.Repositories;

namespace MissTortas.Infrastructure.Interfaces
{
    public interface ISimpleStorageRepository : IRepositoryCrud<ConsultancyFile>
    {
        public Task InsertConsultancyFileAsync(ConsultancyFile cf);
        public Task InsertProductFileAsync(ProductFile pf);
        public Task<List<ProductFile>> GetProductFilesAsync(long productId);
        public Task<Dictionary<long,List<ProductFile>>> GetProductFilesAsync(long[] productsId);
        public Task RemoveFilesProductsAsync(long productId);
    }
}
