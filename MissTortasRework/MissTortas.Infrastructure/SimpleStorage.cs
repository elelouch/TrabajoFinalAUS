using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MissTortas.Domain.Products;
using MissTortas.Infrastructure.Entity.Orders;
using MissTortas.Infrastructure.Exceptions;
using MissTortas.Infrastructure.Interfaces;

namespace MissTortas.Infrastructure
{
    public class SimpleStorage(
        IWebHostEnvironment? webHostEnvironment,
        ISimpleStorageRepository simpleStorageRepository,
        string root = ""
        ) : ISimpleStorage
    {
        private readonly string _root = webHostEnvironment?.WebRootPath ?? root;
        public async Task SaveConsultancyFileAsync(IFormFile fsIn, long consultancyId)
        {
            if (consultancyId == 0)
            {
                throw new ConsultancyException("Consultancy doesn't have an ID");
            }
            var extension = Path.GetExtension(fsIn.FileName);
            var guid = Guid.NewGuid();
            var storageDirectory = Path.Combine(_root, "consultancy");
            var filename = guid.ToString() + extension;
            var relativePath = $"consultancy/{filename}";
            var consultancyFile = new ConsultancyFile()
            {
                Guid = guid,
                ConsultancyId = consultancyId,
                Extension = extension,
                Path = relativePath
            };
            using var fsOut = File.Create(Path.Combine(storageDirectory, filename));
            await fsIn.CopyToAsync(fsOut);
            await simpleStorageRepository.InsertConsultancyFileAsync(consultancyFile);
            await simpleStorageRepository.SaveChangesAsync();
        }

        public async Task SaveConsultancyFileAsync(IEnumerable<IFormFile> files, long consultancyId)
        {
            foreach (var file in files)
            {
                await SaveConsultancyFileAsync(file, consultancyId);
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
