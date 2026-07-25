using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Repositories.DTO;
using MissTortas.View.DTO.Orders;

namespace MissTortas.View.Mappers
{
    public class PresentationOrderMapper(UserManager<ApplicationUser> userManager) : IPresentationOrderMapper
    {
        public async Task<SetupOrderDTO> FromCreateOrderToSetupOrderAsync(CreateOrderRequest createOrder)
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
            return FromOrderDTOToResponse(dto, null);
        }


        public OrderResponse FromOrderDTOToResponse(OrderDTO dto, Dictionary<long, string>? usernamesDictionary)
        {
            var ret = new OrderResponse
            {
                Id = dto.Id,
                Preparations = FromOrderPreparationDTOToResponse(dto.Preparations, usernamesDictionary),
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

        public List<OrderResponse> FromOrderDTOToResponse(IEnumerable<OrderDTO> dtos, Dictionary<long, string>? domainIdToAlias)
        {
            List<OrderResponse> ret = [];
            if(domainIdToAlias != null)
            {
                foreach (var dto in dtos)
                {
                    var orderDto = FromOrderDTOToResponse(dto, domainIdToAlias);
                    if (domainIdToAlias.TryGetValue(dto.ClientId, out var val))
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
            return FromOrderPreparationDTOToResponse(dto, null);
        }
        public OrderPreparationResponse FromOrderPreparationDTOToResponse(OrderPreparationDTO dto, Dictionary<long, string>? domainIdToAlias)
        {
            var ret = new OrderPreparationResponse
            {
                Id = dto.Id,
                Detail = dto.Detail,
                Done = dto.Done,
                OrderId = dto.OrderId
            };
            if (domainIdToAlias != null && domainIdToAlias.TryGetValue(dto.AssigneeId, out var val))
            {
                ret.AssigneeId = val;
            }
            return ret;
        }

        public List<OrderPreparationResponse> FromOrderPreparationDTOToResponse(IEnumerable<OrderPreparationDTO> dtos)
        {
            return FromOrderPreparationDTOToResponse(dtos, null);
        }

        public List<OrderPreparationResponse> FromOrderPreparationDTOToResponse(IEnumerable<OrderPreparationDTO> dtos, Dictionary<long, string>? domainIdToAlias)
        {
            return [.. dtos.Select(op => FromOrderPreparationDTOToResponse(op, domainIdToAlias))];
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

    }
}
