using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.DTO.Products;
using MissTortas.View.DTO.Orders;

namespace MissTortas.View.Mappers
{
    public class ControllerOrderMapper(UserManager<ApplicationUser> userManager) : IControllerOrderMapper
    {
        public async Task<SetupOrderDTO> FromCreateOrderToSetupOrder(CreateOrder createOrder)
        {
            var idMap = await userManager.Users
                .Where(u => u.Id == createOrder.ClientGuid || u.Id == createOrder.OrderManagerGuid)
                .ToDictionaryAsync(u => u.Id, u => u.UserId) ?? [];
            var asks = createOrder.AskedProducts.Select(p => new AskedProductDTO
            {
                QuantityAsked = p.QuantityAsked,
                SaleProductId = p.SaleProductId
            });
            var placeOrder = new SetupOrderDTO
            {
                OrderManagerId = idMap.GetValueOrDefault(createOrder.OrderManagerGuid, 0),
                OrderTypeId = createOrder.OrderTypeId,
                ClientId = idMap.GetValueOrDefault(createOrder.ClientGuid, 0),
                AskedProduct = [.. asks],
                ConsultancyId = 0,
                Description = createOrder.Description
            };
            return placeOrder;
        }

        public OrderResponse FromOrderDTOToResponse(OrderDTO dto)
        {
            var ret = new OrderResponse
            {
                Id = dto.Id,
                Preparations = dto.Preparations,
                StatusId = dto.StatusId,
                Status = dto.Status
            };
            return ret;
        }
    }
}
