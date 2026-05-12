using Misstortas.Frontend.Models;

namespace Misstortas.Frontend.Services.Products
{
    public interface IProductsClient
    {
        public Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
