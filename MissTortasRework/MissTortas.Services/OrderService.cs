using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Interfaces;
using MissTortas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services
{
    public class OrderService(IOrderRepository orderRepository) : IOrderService
    {
        public async Task<List<OrderType>> AllOrderTypeAsync()
        {
            return (await orderRepository.GetAllOrderTypeAsync());
        }
    }
}
