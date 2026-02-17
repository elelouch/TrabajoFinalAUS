using Microsoft.AspNetCore.Hosting;
using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Entity.Products;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;

namespace MissTortas.Services
{
    public class SimpleStorage(IWebHostEnvironment? webHostEnvironment, string root = "") : ISimpleStorage
    {
        private readonly string _root = webHostEnvironment?.ContentRootPath ?? root;

        public async Task SaveConsultancyFileAsync(FileStream fsIn, Consultancy consultancy)
        {
            if (consultancy.Id == 0)
            {
                throw new ConsultancyException("Consultancy doesn't have an ID");
            }
            var extension = Path.GetExtension(fsIn.Name);
            var guid = Guid.NewGuid();
            var newPath = Path.Combine(_root, "consultancy", consultancy.Id.ToString(), guid.ToString(), extension);
            var consultancyFile = new ConsultancyFile()
            {
                Guid = guid,
                Consultancy = consultancy,
                Extension = extension,
                Path = newPath
            };
            consultancy.ConsultancyFiles.Add(consultancyFile);
            using var fsOut = File.Create(newPath);
            await fsIn.CopyToAsync(fsOut);
        }

        public async Task SaveConsultancyFileAsync(IEnumerable<FileStream> files, Consultancy consultancy)
        {
            foreach (var file in files)
            {
                await SaveConsultancyFileAsync(file, consultancy);
            }
        }

        public Task SaveProductFileAsync(FileStream file, Product product)
        {
            throw new NotImplementedException();
        }

        public Task SaveProductFileAsync(IEnumerable<FileStream> files, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
