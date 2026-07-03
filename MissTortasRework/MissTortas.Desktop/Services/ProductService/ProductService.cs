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
        public async Task<List<ProductCategory>> GetCategories()
        {
            var categories = await httpClient.GetAsync<List<ProductCategory>>("categories");
            return categories ?? [];
        }
    }
}
