using Microsoft.AspNetCore.Http;
using MissTortas.Infrastructure.Entity.Products;

namespace MissTortas.Infrastructure.Interfaces
{
    public interface ISimpleStorage
    {
        public Task<ProductFile> SaveProductFileAsync(IFormFile file, long productId);
        public Task<List<ProductFile>> SaveProductFileAsync(IEnumerable<IFormFile> files, long productId);
        public Task SaveConsultancyFileAsync(IFormFile file, long consultancyId);
        public Task SaveConsultancyFileAsync(IEnumerable<IFormFile> files, long consultancyId);
        public Task<List<ProductFile>> GetProductFilesAsync(long productId);

    }
}
