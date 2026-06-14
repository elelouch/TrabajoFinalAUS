using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Services.DTO.Orders;
using MissTortas.View.DTO.Orders;
using MissTortas.Services.DTO.Products;

namespace MissTortas.View.Mappers
{
    public class OrderMapper(UserManager<ApplicationUser> userManager) : IOrderMapper
    {
        public async Task<SetupOrderDTO> FromCreateOrderToSetupOrder(CreateOrder createOrder)
        {
            var idMap = await userManager.Users
                .Include(u => u.UserId)
                .Where(u => u.Id == createOrder.ClientGuid || u.Id == createOrder.OrderManagerGuid)
                .ToDictionaryAsync(u => u.Id, u => u.UserId) ?? [];
            var asks = createOrder.AskedProducts.Select(p => new AskedProductDTO
            {
                QuantityAsked = p.QuantityAsked,
                SaleProductId = p.SaleProductId
            });
            var placeOrder = new SetupOrderDTO
            {
                OrderManagerId = idMap[createOrder.OrderManagerGuid],
                OrderTypeId = createOrder.OrderTypeId,
                ClientId = idMap[createOrder.ClientGuid],
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
