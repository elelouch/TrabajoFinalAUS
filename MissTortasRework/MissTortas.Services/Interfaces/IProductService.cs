using MissTortas.Domain.Products;
using MissTortas.Services.DTO.Products;

namespace MissTortas.Services.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDTO>> AllAsync();
        public Task<IEnumerable<ProductCategoryDTO>> AllProductCategoryAsync();
        public Task<IEnumerable<ProductDTO>> AllWithDetailAsync();
        public Task<ProductDTO> CreateProductAsync(ProductCreateDTO dto);
        public Task<ProductDTO?> GetProductByNameAsync(string name);
        public Task<SaleProductDTO> CreateSaleProductAsync(SaleProductCreateDTO dto);
        public Task<IEnumerable<SaleProductDTO>> GetSaleProductsFromCategoryAsync(long categoryId);
        public Task<IEnumerable<ProductDTO>> GetProductsFromCategoryAsync(long categoryId);
        public Task<SaleProduct> GetSaleProductEntityAsync(long id);
        public Task<SaleProductDTO> GetSaleProductAsync(long id);
        public Task<ProductCategoryDTO> CreateProductCategoryAsync(ProductCategoryCreateDTO dto);
        public Task DeleteProductCategory(long id);
        public Task<ProductDTO?> FindProduct(long id);
        public Task<ProductDTO> UpdateProductAsync(UpdateProductDTO dto);
        public Task<SaleProductDTO> UpdateSaleProductAsync(UpdateSaleProductDTO dto);
    }
}
