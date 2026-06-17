using Microsoft.EntityFrameworkCore;
using MissTortas.Domain.Products;
using MissTortas.Infrastructure.Context;
using MissTortas.Services.Repositories;
using MissTortas.Services.Repositories.DTO;

namespace MissTortas.Infrastructure.Repositories
{
    public class ProductRepository(MissTortasContext context) : RepositoryCrud<Product>(context), IProductRepository
    {
        private readonly DbSet<Product> productsSet = context.Products;
        private readonly DbSet<ProductDetail> productsDetailSet = context.ProductDetails;
        private readonly DbSet<SaleProduct> saleProductSet = context.SaleProducts;
        private readonly DbSet<ProductCategory> productCategoriesSet = context.ProductCategories;

        public Task<List<Product>> GetAllWithDetailAsync() => productsSet.Include(p => p.ProductDetail).ToListAsync();

        public async Task<Product> GetWithDetailAsync(long id) =>
            await productsSet.Include(p => p.ProductDetail).Where(p => p.ProductId == id).SingleAsync();

        public async Task<Product?> FindProductByNameAsync(string name) =>
            await productsSet.Where(p => p.Name == name).FirstOrDefaultAsync();

        public async Task InsertProductDetailAsync(ProductDetail productDetail) => await productsDetailSet.AddAsync(productDetail);

        public async Task InsertSaleProductAsync(SaleProduct saleProduct) => await saleProductSet.AddAsync(saleProduct);

        public async Task<ProductCategory?> FindProductCategoryAsync(long id) => await productCategoriesSet.FindAsync(id);

        public async Task InsertProductCategoryAsync(ProductCategory productCategory)
        {
            await productCategoriesSet.AddAsync(productCategory);
        }

        public Task<List<ProductCategory>> GetAllProductCategoriesAsync()
        {
            return productCategoriesSet.Include(c => c.Parent).ToListAsync();
        }

        public async Task DeleteProductCategory(ProductCategory cat) => productCategoriesSet.Remove(cat);

        public async Task<ProductCategory?> GetProductCategoryAsync(long id)
        {
            return (await productCategoriesSet.FindAsync(id));
        }

        public async Task<SaleProduct?> FindSaleProductAsync(long id)
        {
            return (await saleProductSet.FindAsync(id));
        }

        public Task<List<SaleProduct>> GetSaleProductsFromCategoryAsync(long categoryId)
        {
            var ret = saleProductSet
                .Include(sp => sp.Product)
                .Where(sp => sp.Product.ProductCategoryId == categoryId)
                .ToListAsync();
            return ret;
        }

        public Task<SaleProduct?> GetSaleProductWithStockAsync(long id)
        {
            return saleProductSet
                .Include(sp => sp.Product)
                .ThenInclude(product => product.ProductDetail)
                .Where(sp => sp.SaleProductId == id).SingleOrDefaultAsync();
        }

        public Task<SaleProductEntityDTO?> FindSaleProductDTOAsync(long id)
        {
            var ret = saleProductSet.Select(
                sp => new SaleProductEntityDTO
                {
                    SaleProductId = sp.SaleProductId,
                    ManageQuantityAsInteger = sp.Product.ManageQuantityAsInteger
                }).Where(sp => sp.SaleProductId == id)
                .SingleOrDefaultAsync();
            return ret;
        }
    }
}