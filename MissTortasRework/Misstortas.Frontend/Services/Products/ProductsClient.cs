using Misstortas.Frontend.Models;
using System.Text.Json;

namespace Misstortas.Frontend.Services.Products
{
    public class ProductsClient(HttpClient httpClient) : IProductsClient
    {
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var response = await httpClient.GetAsync("/categories");
            if(!response.IsSuccessStatusCode)
            {
                Console.WriteLine("GetCategoriesAsync had an error");
                return [];
            }
            var ret = await response.Content.ReadFromJsonAsync<Category[]>() ?? [];
            return ret;
        }
    }
}
