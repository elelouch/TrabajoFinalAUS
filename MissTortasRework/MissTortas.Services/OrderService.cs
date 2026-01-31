using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Interfaces;
using MissTortas.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Engine
{
    public class OrderService(IOrderRepository orderRepository) : IOrderService
    {
        public async Task<IEnumerable<OrderType>> AllOrderTypeAsync()
        {
            return (await orderRepository.GetAllOrderTypeAsync());
        }
    }
}
