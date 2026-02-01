using MissTortas.Data.Entity.Orders;
using MissTortas.Services.DTO.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Mapper
{
    public class OrderMapper : IOrderMapper
    {
        public OrderDTO OrderToDTO(Order order)
        {
            return new OrderDTO
            {
                Status = nameof(order.OrderStatus),
                StatusId = (long) order.OrderStatus,
                Id = order.Id,
                ClientId = order.Client?.Id ?? 0,
                OrderMangerId = order.OrderManager?.Id ?? 0
            };
        }

        public OrderTypeDTO OrderTypeToDTO(OrderType ot)
        {
            return new OrderTypeDTO
            {
                Id = ot.Id,
                Name = ot.Name
            };
        }

        public IEnumerable<OrderTypeDTO> OrderTypeToDTO(IEnumerable<OrderType> ots)
        {
            return ots.Select(ot => OrderTypeToDTO(ot));
        }
    }
}
