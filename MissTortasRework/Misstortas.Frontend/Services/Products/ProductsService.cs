using Microsoft.AspNetCore.Components.Authorization;
using Misstortas.Frontend.Models;
using Misstortas.Frontend.Services.Auth;
using Misstortas.Frontend.Services.Shared;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace Misstortas.Frontend.Services.Products
{
    public class ProductsService(IMissTortasClient missTortasClient) : IProductsService
    {
        public long DefaultOrderTypeId = 1;

        public async Task<Category[]> GetCategoriesAsync()
        {
            try
            {
                var result = await missTortasClient.GetAsync<Category[]>("/categories");
                return result ?? [];
            }
            catch (HttpRequestException)
            {
                return [];
            }
        }

        public async Task<SaleProduct[]> GetSaleProductsAsync(long categoryId)
        {
            if (categoryId == 0)
            {
                throw new InvalidDataException("CategoryID cannot be zero");
            }

            try
            {
                var result = await missTortasClient.GetAsync<SaleProduct[]>($"/categories/{categoryId}/saleproducts");
                return result ?? [];
            }
            catch (HttpRequestException)
            {
                return [];
            }
        }
    }
}