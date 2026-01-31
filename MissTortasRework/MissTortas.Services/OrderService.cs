using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Interfaces;
using MissTortas.Services.DTO.Order;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services
{
    public class OrderService(IOrderRepository orderRepository, IOrderMapper orderMapper) : IOrderService
    {
        public async Task<IEnumerable<OrderTypeDTO>> AllOrderTypeAsync()
        {
            var orders = await orderRepository.GetAllOrderTypeAsync();
            return orderMapper.OrderTypeToDTO(orders);
        }
    }
}
