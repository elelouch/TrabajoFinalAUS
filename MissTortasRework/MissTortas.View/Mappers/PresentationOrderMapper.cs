using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.DTO.Products;
using MissTortas.View.DTO.Orders;

namespace MissTortas.View.Mappers
{
    public class PresentationOrderMapper(UserManager<ApplicationUser> userManager) : IPresentationOrderMapper
    {
        public async Task<SetupOrderDTO> FromCreateOrderToSetupOrderAsync(CreateOrder createOrder)
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
                Preparations = FromOrderPreparationDTOToResponse(dto.Preparations),
                StatusId = dto.StatusId,
                Status = dto.Status,
                SaleProducts = FromSaleProductAskedDTOToResponse(dto.SaleProducts),
                CreatedAt = dto.Creation,
                PaymentStatus = dto.PaymentStatus
            };
            return ret;
        } 
        public List<OrderResponse> FromOrderDTOToResponse(IEnumerable<OrderDTO> dtos)
        {
            var ret = FromOrderDTOToResponse(dtos, null);
            return ret;
        }

        public List<OrderResponse> FromOrderDTOToResponse(IEnumerable<OrderDTO> dtos, Dictionary<long, string>? domainIdToAppId)
        {
            List<OrderResponse> ret = [];
            if(domainIdToAppId != null)
            {
                foreach (var dto in dtos)
                {
                    var orderDto = FromOrderDTOToResponse(dto);
                    if (domainIdToAppId.TryGetValue(dto.ClientId, out var val))
                    {
                        orderDto.ClientUserId = val;
                        ret.Add(orderDto);
                    }
                }
            }
            return ret;
        }

        public OrderPreparationResponse FromOrderPreparationDTOToResponse(OrderPreparationDTO dto)
        {
            return new OrderPreparationResponse
            {
                Id = dto.Id,
                Detail = dto.Detail,
                Done = dto.Done,
                AssigneeId = dto.AssigneeId,
                OrderId = dto.OrderId
            };
        }

        public List<OrderPreparationResponse> FromOrderPreparationDTOToResponse(IEnumerable<OrderPreparationDTO> dtos)
        {
            return [.. dtos.Select(FromOrderPreparationDTOToResponse)];
        }

        public List<SaleProductAskedResponse> FromSaleProductAskedDTOToResponse(IEnumerable<SaleProductAskedDTO> dtos)
        {
            return [..dtos.Select(FromSaleProductAskedDTOToResponse)];
        }

        public SaleProductAskedResponse FromSaleProductAskedDTOToResponse(SaleProductAskedDTO dto)
        {
            return new SaleProductAskedResponse
            {
                Id = dto.Id,
                Description = dto.Description,
                Name = dto.Name,
                Price = dto.SalePrice,
                QuantityAsked = dto.SaleQuantity
            };
        }

        public OrderPreparationResponse FromSaleProductAskedToDTO(OrderPreparationDTO dto)
        {
            return new OrderPreparationResponse
            {
                Id = dto.Id,
                Detail = dto.Detail,
                Done = dto.Done,
                AssigneeId = dto.AssigneeId,
                OrderId = dto.OrderId
            };
        }
    }
}
