using MissTortas.Services.DTO.Orders;
using MissTortas.View.DTO.Orders;

namespace MissTortas.View.Mappers
{
    public interface IPresentationOrderMapper
    {
        public Task<OrderResponse> FromOrderDTOToResponse(OrderDTO dto);
        public Task<OrderPreparationResponse> FromOrderPreparationDTOToResponse(OrderPreparationDTO dto);
        public OrderPreparationResponse FromOrderPreparationDTOToResponse(OrderPreparationDTO dto, Dictionary<long, string>? domainIdToAppId);
        public Task<List<OrderPreparationResponse>> FromOrderPreparationDTOToResponse(IEnumerable<OrderPreparationDTO> dtos);
        public Task<List<OrderPreparationResponse>> FromOrderPreparationDTOToResponse(IEnumerable<OrderPreparationDTO> dtos, Dictionary<long, string>? domainIdToAppId);
        public SaleProductAskedResponse FromSaleProductAskedDTOToResponse(SaleProductAskedDTO dto);
        public List<SaleProductAskedResponse> FromSaleProductAskedDTOToResponse(IEnumerable<SaleProductAskedDTO> dtos);
        public Task<List<OrderResponse>> FromOrderDTOToResponse(IEnumerable<OrderDTO> dtos);
        public Task<List<OrderResponse>> FromOrderDTOToResponse(IEnumerable<OrderDTO> dtos, Dictionary<long, string>? domainIdToAppId);
        public Task<SetupOrderDTO> FromCreateOrderToSetupOrderAsync(CreateOrderRequest createOrder);
        public Task<OrderResponse> FromOrderDTOToResponse(OrderDTO dto, Dictionary<long, string>? UsernamesDictionary);

    }
}
