using Misstortas.Frontend.Models;
using System.Text.Json;

namespace Misstortas.Frontend.Services.Products
{
    public class ProductsClient(HttpClient httpClient) : IProductsClient
    {
        public async Task<Category[]> GetCategoriesAsync()
        {
            var response = await httpClient.GetAsync("/categories");
            if(!response.IsSuccessStatusCode)
            {
                return [];
            }
            var ret = await response.Content.ReadFromJsonAsync<Category[]>() ?? [];
            return ret;
        }

        public async Task<SaleProduct[]> GetSaleProductsAsync(long categoryId)
        {
            if(categoryId == 0)
            {
                throw new InvalidDataException("CategoryID cannot be zero");
            }    
            var response = await httpClient.GetAsync($"/categories/{categoryId}/saleproducts");
            if (!response.IsSuccessStatusCode)
            {
                return [];
            }
            var result = await response.Content.ReadFromJsonAsync<SaleProduct[]>() ?? [];
            return result;
        }

        public async Task PostCartAsync(Dictionary<long, SaleProduct> cart)
        {
            
        }

    }
}
