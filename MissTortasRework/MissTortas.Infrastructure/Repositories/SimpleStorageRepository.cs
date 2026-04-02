using Microsoft.EntityFrameworkCore;
using MissTortas.Domain.Products;
using MissTortas.Infrastructure.Context;
using MissTortas.Infrastructure.Entity.Orders;
using MissTortas.Repository;

namespace MissTortas.Infrastructure.Repositories
{
    public class SimpleStorageRepository(MissTortasContext context) : RepositoryCrud<ProductFile>(context), ISimpleStorageRepository
    {
        private readonly DbSet<ConsultancyFile> consultancyFiles = context.ConsultancyFiles;
        private readonly DbSet<ProductFile> productFiles = context.ProductFiles;

        public async Task InsertConsultancyFileAsync(ConsultancyFile cf)
        {
            await consultancyFiles.AddAsync(cf);
        }
    }
}
