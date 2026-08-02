using Microsoft.AspNetCore.Components.Authorization;
using Misstortas.Frontend.Services.Products;
using Misstortas.Frontend.Services.Shared;
using System.IdentityModel.Tokens.Jwt;

namespace Misstortas.Frontend.Services.Order
{
    public class OrderService(IMissTortasClient missTortasClient, ISaleProductCartService cartService, AuthenticationStateProvider stateProvider) : IOrderService
    {
        public long DefaultOrderTypeId = 1;
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