using MissTortas.Services.DTO.Orders;
using MissTortas.View.DTO.Orders;

namespace MissTortas.View.Mappers
{
    public interface IPresentationOrderMapper
    {
        public OrderResponse FromOrderDTOToResponse(OrderDTO dto);
        public Task<SetupOrderDTO> FromCreateOrderToSetupOrder(CreateOrder createOrder);
    }
}
