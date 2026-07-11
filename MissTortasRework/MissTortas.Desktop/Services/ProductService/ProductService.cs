using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Services.ProductService
{
    public class ProductService : IProductService
    {
        public MissTortasHttpClient httpClient;
        public ProductService(MissTortasHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Product> CreateProductAsync(Product pc)
        {
            var ret = await httpClient.PostAsync<Product>("products", pc);
            return ret!;
        }

        public async Task<ProductCategory?> CreateProductCategoryAsync(ProductCategory pc)
        {
            var ret = await httpClient.PostAsync<ProductCategory>("categories", pc);
            return ret;
        }

        public async Task<List<ProductCategory>> GetCategoriesAsync()
        {
            var categories = await httpClient.GetAsync<List<ProductCategory>>("categories?enabled=true");
            return categories ?? [];
        }

        public async Task<Dictionary<long, ProductCategory>> GetProductCategoryDictionaryAsync(ProductCategory pc)
        {
            var categories = await httpClient.GetAsync<List<ProductCategory>>("categories");
            if(categories == null)
            {
                throw new InvalidOperationException("Categories can not be null");
            }
            return categories.ToDictionary(c => c.ProductCategoryId, c => c);
        }

        public async Task<List<Product>> GetProductsFromCategoryAsync(long categoryId)
        {
            var products = await httpClient.GetAsync<List<Product>>($"categories/{categoryId}/products");
            return products ?? [];
        }

        public async Task<Product> ModifyProductAsync(Product product)
        {
            var ret = await httpClient.PutAsync<Product>($"products/{product.CategoryId}");
            return ret!;
        }

        public async Task UpdateProductCategoryAsync(ProductCategory pc)
        {
            await httpClient.PutAsync<object>($"categories/{pc.ProductCategoryId}", pc);
        }
    }
}
