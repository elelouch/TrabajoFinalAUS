using Microsoft.AspNetCore.Http;
using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Entity.Products;

namespace MissTortas.Services.Interfaces
{
    public interface ISimpleStorage
    {
        public Task SaveProductFileAsync(FileStream file, Product product);
        public Task SaveProductFileAsync(IEnumerable<FileStream> files, Product product);
        public Task SaveConsultancyFileAsync(IFormFile file,Consultancy consultancy);
        public Task SaveConsultancyFileAsync(IEnumerable<IFormFile> files, Consultancy consultancy);
    }
}
