using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Entity.Products;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;

namespace MissTortas.Services
{
    public class SimpleStorage(IWebHostEnvironment? webHostEnvironment, string root = "") : ISimpleStorage
    {
        private readonly string _root = webHostEnvironment?.WebRootPath ?? root;
        public async Task SaveConsultancyFileAsync(IFormFile fsIn, Consultancy consultancy)
        {
            if (consultancy.Id == 0)
            {
                throw new ConsultancyException("Consultancy doesn't have an ID");
            }
            var extension = Path.GetExtension(fsIn.FileName);
            var guid = Guid.NewGuid();
            var newDirectory = Path.Combine(_root, "consultancy", consultancy.Id.ToString());
            if(!Directory.Exists(newDirectory))
            {
                Directory.CreateDirectory(newDirectory);
            }
            var newPath = Path.Combine(newDirectory, guid.ToString() + extension);
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

        public async Task SaveConsultancyFileAsync(IEnumerable<IFormFile> files, Consultancy consultancy)
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
