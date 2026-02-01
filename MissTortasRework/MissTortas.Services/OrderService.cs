using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Entity.Security;
using MissTortas.Data.Interfaces;
using MissTortas.Services.DTO.Order;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapper;

namespace MissTortas.Services
{
    public class OrderService(
        UserManager<ApplicationUser> userManager,
        IOrderRepository orderRepository,
        IOrderMapper orderMapper) : IOrderService
    {
        public async Task<IEnumerable<OrderTypeDTO>> AllOrderTypeAsync()
        {
            var orders = await orderRepository.GetAllOrderTypeAsync();
            return orderMapper.OrderTypeToDTO(orders);
        }

        public Task<OrderDTO> PlaceOrder(PlaceOrderDTO dto)
        {
            var client = userManager.FindByIdAsync(dto.ClientId.ToString()) ?? throw new UserNotFoundException("Client not found");
            var orderManager = userManager.FindByIdAsync(dto.OrderManagerId.ToString()) ?? throw new UserNotFoundException("Order manager not found");
            var consultancy = orderRepository.FindConsultancyAsync(dto.ConsultancyId);
            
        }
    }
}
