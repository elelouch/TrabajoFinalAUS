using MissTortas.Data.Entity.Products;
using MissTortas.Engine.DTO.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Engine.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> AllAsync();
        public Task<IEnumerable<Product>> AllWithDetailAsync();
        public Task<Product> CreateProductAsync(ProductCreateDTO dto);
        public Task<Product?> GetProductByNameAsync(string name);
        public Task<SaleProduct> CreateSaleProductAsync(SaleProductCreateDTO dto);
        public Task<ProductCategory> CreateProductCategoryAsync(ProductCategoryCreateDTO dto);
        public Task<IEnumerable<ProductCategory>> AllProductCategoriesAsync();
        public Task<IEnumerable<ProductCategory>> AllProductCategoriesWithParentAsync();
        public Task DeleteProductCategory(long id);
    }
}
