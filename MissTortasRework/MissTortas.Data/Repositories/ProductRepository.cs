using Microsoft.EntityFrameworkCore;
using MissTortas.Data.Context;
using MissTortas.Data.Entity.Products;
using MissTortas.Data.Interfaces;

namespace MissTortas.Data.Repositories
{
    public class ProductRepository(MissTortasContext context) : RepositoryCrud<Product>(context), IProductRepository
    {
        public DbSet<Product> productsSet = context.Products;
        public DbSet<ProductDetail> productsDetailSet = context.ProductDetails;
        public DbSet<SaleProduct> saleProductSet = context.SaleProducts;

        public async Task<IEnumerable<Product>> GetAllWithDetailAsync()
        {
            return (await productsSet.Include(p => p.ProductDetail).ToListAsync());
        }

        public Task<Product?> FindProductByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task InsertProductDetailAsync(ProductDetail productDetail)
        {
            await productsDetailSet.AddAsync(productDetail);
        }

        public async Task InsertSaleProductAsync(SaleProduct saleProduct)
        {
            await saleProductSet.AddAsync(saleProduct);
        }

    }
}
