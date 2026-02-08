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
        public DbSet<ProductCategory> productCategoriesSet = context.ProductCategories;

        public async Task<IEnumerable<Product>> GetAllWithDetailAsync() =>
            await productsSet.Include(p => p.ProductDetail).ToListAsync();

        public async Task<Product> GetWithDetailAsync(long id) =>
            await productsSet.Include(p => p.ProductDetail).Where(p => p.Id == id).SingleAsync();

        public async Task<Product?> FindProductByNameAsync(string name) =>
            await productsSet.Where(p => p.Name == name).FirstOrDefaultAsync();

        public async Task InsertProductDetailAsync(ProductDetail productDetail) => await productsDetailSet.AddAsync(productDetail);

        public async Task InsertSaleProductAsync(SaleProduct saleProduct) => await saleProductSet.AddAsync(saleProduct);

        public async Task<ProductCategory?> FindProductCategoryAsync(long id) => await productCategoriesSet.FindAsync(id);

        public async Task InsertProductCategoryAsync(ProductCategory productCategory) => await productCategoriesSet.AddAsync(productCategory);

        public async Task<IEnumerable<ProductCategory>> GetAllProductCategoriesAsync()
        {
            var categoriesTask = productCategoriesSet.Include(c => c.Parent)
                    //.Include(c => c.Children)
                    .ToListAsync();
            return (await categoriesTask);
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

    }
}