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

        public async Task<ProductCategory?> CreateProductCategoryAsync(ProductCategory pc)
        {
            var ret = await httpClient.PostAsync<ProductCategory>("categories", pc);
            return ret;
        }

        public async Task<List<ProductCategory>> GetCategoriesAsync()
        {
            var categories = await httpClient.GetAsync<List<ProductCategory>>("categories");
            return categories ?? [];
        }

        public async Task<List<Product>> GetProductsFromCategoryAsync(long categoryId)
        {
            var products = await httpClient.GetAsync<List<Product>>($"categories/{categoryId}/products");
            return products ?? [];
        }
    }
}
