using Microsoft.EntityFrameworkCore;
using MissTortas.Domain.Products;
using MissTortas.Infrastructure.Context;
using MissTortas.Repository;

namespace MissTortas.Infrastructure.Repositories
{
    public class ProductRepository(MissTortasContext context) : RepositoryCrud<Product>(context), IProductRepository
    {
        private readonly DbSet<Product> productsSet = context.Products;
        private readonly DbSet<ProductDetail> productsDetailSet = context.ProductDetails;
        private readonly DbSet<SaleProduct> saleProductSet = context.SaleProducts;
        private readonly DbSet<ProductCategory> productCategoriesSet = context.ProductCategories;

        public IAsyncEnumerable<Product> GetAllWithDetail() => productsSet.Include(p => p.ProductDetail).AsAsyncEnumerable();

        public async Task<Product> GetWithDetailAsync(long id) =>
            await productsSet.Include(p => p.ProductDetail).Where(p => p.Id == id).SingleAsync();

        public async Task<Product?> FindProductByNameAsync(string name) =>
            await productsSet.Where(p => p.Name == name).FirstOrDefaultAsync();

        public async Task InsertProductDetailAsync(ProductDetail productDetail) => await productsDetailSet.AddAsync(productDetail);

        public async Task InsertSaleProductAsync(SaleProduct saleProduct) => await saleProductSet.AddAsync(saleProduct);

        public async Task<ProductCategory?> FindProductCategoryAsync(long id) => await productCategoriesSet.FindAsync(id);

        public async Task InsertProductCategoryAsync(ProductCategory productCategory) => await productCategoriesSet.AddAsync(productCategory);

        public IAsyncEnumerable<ProductCategory> GetAllProductCategoriesAsync()
        {
            var categoriesTask = productCategoriesSet.Include(c => c.Parent)
                    .AsAsyncEnumerable();
            return categoriesTask;
        }

        public async Task DeleteProductCategory(ProductCategory cat) =>
            productCategoriesSet.Remove(cat);

        public async Task<ProductCategory?> GetProductCategory(long id)
        {
            return (await productCategoriesSet.FindAsync(id));
        }

        public async Task<SaleProduct?> FindSaleProductAsync(long id)
        {
            return (await saleProductSet.Include(sp => sp.StockProduct).SingleAsync(sp => sp.Id == id));
        }

        public IAsyncEnumerable<ProductCategory> GetAllProductCategories()
        {
            return productCategoriesSet.AsAsyncEnumerable();
        }
    }
}