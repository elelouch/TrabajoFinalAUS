using MissTortas.Data.Entity.Products;

namespace MissTortas.Data.Interfaces
{
    public interface IProductRepository: IRepositoryCrud<Product>
    {
        public Task InsertProductCategoryAsync(ProductCategory productCategory);
        public Task<ProductCategory?> FindProductCategoryAsync(long id);
        public Task InsertProductDetailAsync(ProductDetail productDetail);
        public Task InsertSaleProductAsync(SaleProduct saleProduct);
        public Task<SaleProduct?> FindSaleProductAsync(long id);
        public Task<Product?> FindProductByNameAsync(string name);
        public Task<IEnumerable<Product>> GetAllWithDetailAsync();
        public Task<ProductCategory?> GetProductCategory(long id);
        public Task DeleteProductCategory(ProductCategory pc);
        public Task<IEnumerable<ProductCategory>> GetAllProductCategoriesAsync();
    }
}
