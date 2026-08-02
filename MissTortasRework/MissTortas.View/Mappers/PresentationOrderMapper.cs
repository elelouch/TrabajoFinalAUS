using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MissTortas.Domain.Orders;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Interface;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Repositories.DTO;
using MissTortas.View.DTO.Orders;

namespace MissTortas.View.Mappers
{
    public class PresentationOrderMapper(
        UserManager<ApplicationUser> userManager,
        ISecurityService securityService
    ) : IPresentationOrderMapper
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

        public async Task<OrderResponse> FromOrderDTOToResponse(OrderDTO dto)
        {
            var dict = await securityService.UserDomainIdToUsernameAsync([dto.ClientId, dto.OrderMangerId]);
            return await FromOrderDTOToResponse(dto, dict);
        }


        public async Task<OrderResponse> FromOrderDTOToResponse(OrderDTO dto, Dictionary<long, string>? usernamesDictionary)
        {
            var ret = new OrderResponse
            {
                Id = dto.Id,
                Preparations = await FromOrderPreparationDTOToResponse(dto.Preparations, usernamesDictionary),
                StatusId = dto.StatusId,
                Status = dto.Status,
                SaleProducts = FromSaleProductAskedDTOToResponse(dto.SaleProducts),
                CreatedAt = dto.Creation,
                PaymentStatus = dto.PaymentStatus
            };
            return ret;
        } 
        public async Task<List<OrderResponse>> FromOrderDTOToResponse(IEnumerable<OrderDTO> dtos)
        {
            var clientIds = dtos.Select(o => o.ClientId);
            var orderManagerIds = dtos.Select(o => o.OrderMangerId);
            var dict = await securityService.UserDomainIdToUsernameAsync([..orderManagerIds.Union(clientIds)]);
            var ret = await FromOrderDTOToResponse(dtos, null);
            return ret;
        }

        public async Task<List<OrderResponse>> FromOrderDTOToResponse(IEnumerable<OrderDTO> dtos, Dictionary<long, string>? domainIdToAlias)
        {
            List<OrderResponse> ret = [];
            if(domainIdToAlias != null)
            {
                foreach (var dto in dtos)
                {
                    var orderDto = await FromOrderDTOToResponse(dto, domainIdToAlias);
                    if (domainIdToAlias.TryGetValue(dto.ClientId, out var val))
                    {
                        orderDto.ClientUserId = val;
                        ret.Add(orderDto);
                    }
                }
            }
            return ret;
        }

        public async Task<OrderPreparationResponse> FromOrderPreparationDTOToResponse(OrderPreparationDTO dto)
        {
            var dict = await securityService.UserDomainIdToUsernameAsync([dto.AssigneeId]);
            return FromOrderPreparationDTOToResponse(dto, dict);
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

        public async Task<List<OrderPreparationResponse>> FromOrderPreparationDTOToResponse(IEnumerable<OrderPreparationDTO> dtos)
        {
            var dict = await securityService.UserDomainIdToUsernameAsync([..dtos.Select(p => p.AssigneeId)]);
            return await FromOrderPreparationDTOToResponse(dtos, dict);
        }

        public async Task<List<OrderPreparationResponse>> FromOrderPreparationDTOToResponse(IEnumerable<OrderPreparationDTO> dtos, Dictionary<long, string>? domainIdToAlias)
        {
            return [.. dtos.Select(op => FromOrderPreparationDTOToResponse(op, domainIdToAlias))];
        }

        public List<SaleProductAskedResponse> FromSaleProductAskedDTOToResponse(IEnumerable<SaleProductAskedDTO> dtos)
        {
            return [..dtos.Select(FromSaleProductAskedDTOToResponse)];
        }

        public SaleProductAskedResponse FromSaleProductAskedDTOToResponse(SaleProductAskedDTO dto)
        {
            var ret = new SaleProductAskedResponse
            {
                Id = dto.Id,
                Description = dto.Description,
                Name = dto.Name,
                Price = dto.SalePrice,
                QuantityAsked = dto.SaleQuantity
            };
            return ret;
        }

    }
}
