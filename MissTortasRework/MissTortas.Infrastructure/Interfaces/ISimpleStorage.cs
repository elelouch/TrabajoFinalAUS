using Microsoft.AspNetCore.Http;
using MissTortas.Domain.Orders;
using MissTortas.Domain.Products;

namespace MissTortas.Infrastructure.Interfaces
{
    public interface ISimpleStorage
    {
        public Task SaveProductFileAsync(FileStream file, Product product);
        public Task SaveProductFileAsync(IEnumerable<FileStream> files, Product product);
        public Task SaveConsultancyFileAsync(IFormFile file, Consultancy consultancy);
        public Task SaveConsultancyFileAsync(IEnumerable<IFormFile> files, Consultancy consultancy);
    }
}
