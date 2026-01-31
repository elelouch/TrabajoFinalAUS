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

        public async Task<Product?> GetProductByNameAsync(string name) =>
            await productsSet.Where(p => p.Name == name).FirstOrDefaultAsync();

        public async Task InsertProductDetailAsync(ProductDetail productDetail) => await productsDetailSet.AddAsync(productDetail);

        public async Task InsertSaleProductAsync(SaleProduct saleProduct) => await saleProductSet.AddAsync(saleProduct);

        public async Task<ProductCategory?> GetProductCategoryAsync(long id) => await productCategoriesSet.FindAsync(id);

        public async Task InsertProductCategoryAsync(ProductCategory productCategory) => await productCategoriesSet.AddAsync(productCategory);

        public async Task<IEnumerable<ProductCategory>> GetAllProductCategoriesAsync() => await productCategoriesSet.ToListAsync();

        public async Task<IEnumerable<ProductCategory>> GetAllProductCategoriesWithParentAsync() =>
            await productCategoriesSet.Include(s => s.Parent).ToListAsync();

        public async Task DeleteProductCategory(ProductCategory cat) =>
            productCategoriesSet.Remove(cat);
    }
}