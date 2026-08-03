using Microsoft.AspNetCore.Components.Authorization;
using Misstortas.Frontend.Models;
using Misstortas.Frontend.Services.Products;
using Misstortas.Frontend.Services.Shared;
using System.IdentityModel.Tokens.Jwt;

namespace Misstortas.Frontend.Services.Orders
{
    public class OrderService(IMissTortasClient missTortasClient, ISaleProductCartService cartService, AuthenticationStateProvider stateProvider) : IOrderService
    {
        public long DefaultOrderTypeId = 1;

        public async Task CancelOrderByIdAsync(long id)
        {
            await missTortasClient.PatchAsync<object>($"orders/{id}", new { Status = "cancel" });
        }

        public async Task<Order> GetOrderByIdAsync(long orderId)
        {
            var order = await missTortasClient.GetAsync<Order>($"orders/{orderId}");
            return order!;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            var ret = await missTortasClient.GetAsync<List<Order>>("/orders");
            return ret!;
        }

        public async Task<long> PostCartAsync()
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
                OrderTypeId = DefaultOrderTypeId
            };

            var ret = await missTortasClient.PostAsync<OrderResponseDTO>("/orders", req);
            return ret!.Id;
        }
    }


}