using MissTortas.Domain.Products;
using MissTortas.Services.DTO.Products;

namespace MissTortas.Services.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDTO>> AllAsync();
        public Task<IEnumerable<ProductDTO>> AllWithDetailAsync();
        public Task<ProductDTO> CreateProductAsync(ProductCreateDTO dto);
        public Task<ProductDTO?> GetProductByNameAsync(string name);
        public Task<SaleProductDTO> CreateSaleProductAsync(SaleProductCreateDTO dto);
        public Task<IEnumerable<SaleProductDTO>> GetSaleProductsFromCategoryAsync(long categoryId);
        public Task<SaleProduct> GetSaleProductEntityAsync(long id);
        public Task<CategoryDTO> CreateProductCategoryAsync(ProductCategoryCreateDTO dto);
        public Task<IEnumerable<CategoryDTO>> AllCategoriesAvailableAsync();
        public Task DeleteProductCategory(long id);
        public Task<ProductDTO?> FindProduct(long id);
        public Task<ProductDTO> UpdateProductAsync(UpdateProductDTO dto);
    }
}
