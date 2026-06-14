using Microsoft.AspNetCore.Components.Authorization;
using Misstortas.Frontend.Models;
using Misstortas.Frontend.Services.Products;
using Misstortas.Frontend.Services.Shared;
using System.IdentityModel.Tokens.Jwt;

namespace Misstortas.Frontend.Services.Order
{
    public class OrderService(IMissTortasClient missTortasClient, ISaleProductCartService cartService, AuthenticationStateProvider stateProvider) : IOrderService
    {
        public async Task PostCartAsync(PostCartRequestDTO postCartRequest)
        {
            await cartService.LoadAsync();
            var itemsList = cartService.Items
                .Select(item => new AskedProductDTO
                {
                    SaleProductId = item.Product.Id,
                    QuantityAsked = item.QuantityAsked
                })
                .ToList();

            var claimsPrincipal = await stateProvider.GetAuthenticationStateAsync();
            var sub = claimsPrincipal.User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value ?? "";

            var req = new CreateOrderDTO
            {
                AskedProducts = itemsList,
                ClientGuid = sub,
                Description = "Automatically generated.",
                OrderTypeId = postCartRequest.OrderTypeId
            };

            await missTortasClient.PostAsync<object>("/orders", req);
        }
    }
}