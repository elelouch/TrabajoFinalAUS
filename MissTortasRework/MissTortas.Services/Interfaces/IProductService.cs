using MissTortas.Data.Entity.Products;
using MissTortas.Services.DTO.Order;
using MissTortas.Services.DTO.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDTO>> AllAsync();
        public Task<IEnumerable<ProductDTO>> AllWithDetailAsync();
        public Task<ProductDTO> CreateProductAsync(ProductCreateDTO dto);
        public Task<ProductDTO?> GetProductByNameAsync(string name);
        public Task<SaleProductDTO> CreateSaleProductAsync(SaleProductCreateDTO dto);
        public Task<ProductCategoryDTO> CreateProductCategoryAsync(ProductCategoryCreateDTO dto);
        public Task<IEnumerable<ProductCategoryDTO>> AllProductCategoriesAsync();
        public Task DeleteProductCategory(long id);
    }
}
