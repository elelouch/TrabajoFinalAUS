using Misstortas.Frontend.Models;

namespace Misstortas.Frontend.Services.Products
{
    public interface IProductsClient
    {
        public Task<Category[]> GetCategoriesAsync();
        public Task<SaleProduct[]> GetSaleProductsAsync(long categoryId);
    }
}
