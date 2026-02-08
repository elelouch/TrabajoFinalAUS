using MissTortas.Data.Entity.Orders;
using MissTortas.Services.DTO.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Mapper
{
    public class OrderMapper : IOrderMapper
    {
        public OrderDTO OrderToDTO(Order order)
        {
            var preparations = order.Preparations.Select(
                prep => new OrderPreparationDTO 
                { 
                    Id = prep.Id,
                    Detail = prep.Detail,
                    Done = prep.Done
                }).ToList();

            return new OrderDTO
            {
                Status = order.OrderStatus.ToString(),
                StatusId = (long)order.OrderStatus,
                Id = order.Id,
                ClientId = order.Client?.Id ?? 0,
                OrderMangerId = order.OrderManager?.Id ?? 0,
                Preparations = preparations
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
