using Microsoft.AspNetCore.Http;
using MissTortas.Domain.Products;

namespace MissTortas.Infrastructure.Interfaces
{
    public interface ISimpleStorage
    {
        public Task SaveProductFileAsync(IFormFile file, long productId);
        public Task SaveProductFileAsync(IEnumerable<IFormFile> files, long productId);
        public Task SaveConsultancyFileAsync(IFormFile file, long consultancyId);
        public Task SaveConsultancyFileAsync(IEnumerable<IFormFile> files, long consultancyId);
    }
}
