using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MissTortas.Domain.Orders;
using MissTortas.Domain.Products;
using MissTortas.Infrastructure.Entity.Orders;
using MissTortas.Infrastructure.Entity.Products;
using MissTortas.Infrastructure.Exceptions;
using MissTortas.Infrastructure.Interfaces;

namespace MissTortas.Infrastructure
{
    public class SaveFileDTO 
    {
        public required IFormFile FormFile { get; set; }
        public required string StorageDirectory { get; set; }
    }

    public class FileDTO
    {
        public string RelativePath { get; set; } = string.Empty;
    }

    public class SimpleStorage(
        IWebHostEnvironment? webHostEnvironment,
        ISimpleStorageRepository simpleStorageRepository,
        string root = ""
        ) : ISimpleStorage
    {
        private readonly string _root = webHostEnvironment?.WebRootPath ?? root;

        private async Task<FileDTO> SaveFileAsync(SaveFileDTO saveFileDTO)
        {
            var extension = Path.GetExtension(saveFileDTO.FormFile.FileName);
            var storageDirectory = Path.Combine(_root, saveFileDTO.StorageDirectory);
            var filename = Guid.NewGuid().ToString() + extension;
            var relativePath = $"{saveFileDTO.StorageDirectory}/{filename}";
            using var fsOut = File.Create(Path.Combine(storageDirectory, filename));
            await saveFileDTO.FormFile.CopyToAsync(fsOut);
            return new FileDTO
            {
                RelativePath = relativePath
            };
        }

        public async Task SaveConsultancyFileAsync(IFormFile fsIn, long consultancyId)
        {
            if (consultancyId == 0)
            {
                throw new ConsultancyException("ConsultancyID is zero");
            }

            var saveFileDTO = new SaveFileDTO { StorageDirectory = "consultancies", FormFile = fsIn };
            var fileDTO = await SaveFileAsync(saveFileDTO);
            
            var consultancyFile = new ConsultancyFile()
            {
                ConsultancyId = consultancyId,
                Path = fileDTO.RelativePath
            };
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

        public async Task SaveProductFileAsync(IEnumerable<IFormFile> files, long productId)
        {
            foreach (var file in files)
            {
                await SaveProductFileAsync(file, productId);
            }
        }

        public async Task SaveProductFileAsync(IFormFile file, long productId)
        {
            if (productId == 0)
            {
                throw new ConsultancyException("ProductID is zero");
            }

            var saveFileDTO = new SaveFileDTO { StorageDirectory = "products", FormFile = file };
            var fileDTO = await SaveFileAsync(saveFileDTO);

            var productFile = new ProductFile()
            {
                ProductId = productId,
                Path = fileDTO.RelativePath
            };
            await simpleStorageRepository.InsertProductFileAsync(productFile);
            await simpleStorageRepository.SaveChangesAsync();
        }
    }
}
