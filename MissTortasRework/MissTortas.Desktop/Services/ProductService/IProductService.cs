using MissTortas.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Services.ProductService
{
    public interface IProductService
    {
        public Task<Product> ModifyProductAsync(Product product);
        public Task<List<ProductCategory>> GetCategoriesAsync();
        public Task<List<Product>> GetProductsFromCategoryAsync(long id);
        public Task<ProductCategory?> CreateProductCategoryAsync(ProductCategory pc);
        public Task UpdateProductCategoryAsync(ProductCategory pc);
        public Task<Product> CreateProductAsync(Product pc);
    }
}
