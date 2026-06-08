using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MissTortas.Domain.Products;
using MissTortas.Infrastructure.Context;
using MissTortas.Infrastructure.Entity.Orders;
using MissTortas.Infrastructure.Entity.Products;
using MissTortas.Infrastructure.Interfaces;

namespace MissTortas.Infrastructure.Repositories
{
    public class SimpleStorageRepository(MissTortasContext context) : RepositoryCrud<ConsultancyFile>(context), ISimpleStorageRepository
    {
        private readonly DbSet<ConsultancyFile> consultancyFiles = context.ConsultancyFiles;
        private readonly DbSet<ProductFile> productFiles = context.ProductFiles;

        public Task<List<ProductFile>> GetProductFilesAsync(long productId)
        {
            return productFiles.Where(p => p.ProductId == productId).ToListAsync();
        }

        public async Task InsertConsultancyFileAsync(ConsultancyFile cf)
        {
            await consultancyFiles.AddAsync(cf);
        }

        public async Task InsertProductFileAsync(ProductFile pf)
        {
            await productFiles.AddAsync(pf);
        }
    }
}
