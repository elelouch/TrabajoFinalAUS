using MissTortas.Domain.Products;
using MissTortas.Domain.Security.Authorization;
using MissTortas.Services.Repositories.DTO;

namespace MissTortas.Services.Repositories
{
    public interface IProductRepository : IRepositoryCrud<Product>
    {
        public IAsyncEnumerable<SaleProduct> GetSaleProductsFromCategoryAsync(long categoryId);
        public IAsyncEnumerable<ProductCategory> GetProductCategoriesForSubjects(AccessType[] accessTypes, long[] subjects);
        public Task InsertProductCategoryAsync(ProductCategory productCategory);
        public Task<Product> GetWithDetailAsync(long id);
        public Task<ProductCategory?> FindProductCategoryAsync(long id);
        public Task<ProductCategoryRightsDto?> GetProductCategoryWithRights(long id);
        public Task InsertProductDetailAsync(ProductDetail productDetail);
        public Task InsertSaleProductAsync(SaleProduct saleProduct);
        public Task<SaleProduct?> FindSaleProductAsync(long id);
        public Task<Product?> FindProductByNameAsync(string name);
        public IAsyncEnumerable<Product> GetAllWithDetail();
        public Task<ProductCategory?> GetProductCategory(long id);
        public Task DeleteProductCategory(ProductCategory pc);
        public IAsyncEnumerable<ProductCategory> GetAllProductCategories();
    }
}
