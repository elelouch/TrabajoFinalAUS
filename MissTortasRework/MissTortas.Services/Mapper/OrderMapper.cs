using MissTortas.Data.Entity.Orders;
using MissTortas.Services.DTO.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Mapper
{
    public class OrderMapper : IOrderMapper
    {
        public ConsultancyDTO ConsultancyToDTO(Consultancy consultancy)
        {
            var filePaths = consultancy.ConsultancyFiles.Select(f => f.Path);
            var ret = new ConsultancyDTO
            {
                Id = consultancy.Id,
                Title = consultancy.Title,
                Notes = consultancy.Notes,
                StatusId = (int)consultancy.Status,
                Status = consultancy.Status.ToString(),
                FilePaths = [..filePaths]
            };
            return ret;
        }

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
                ClientId = order.Consultancy?.Client?.Id ?? 0,
                OrderMangerId = order.Consultancy?.Assignee?.Id ?? 0,
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
