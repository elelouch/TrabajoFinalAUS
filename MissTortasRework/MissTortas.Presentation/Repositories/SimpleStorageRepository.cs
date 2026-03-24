using Microsoft.EntityFrameworkCore;
using MissTortas.Data.Context;
using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Entity.Products;
using MissTortas.Data.Interfaces;

namespace MissTortas.Data.Repositories
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
