using MissTortas.Domain.Orders;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.Mapping.Interfaces;

namespace MissTortas.Services.Mapping
{
    public class OrderMapper : IOrderMapper
    {
        public ConsultancyDTO ConsultancyToDTO(Consultancy consultancy)
        {
            var ret = new ConsultancyDTO
            {
                Id = consultancy.ResourceId,
                Title = consultancy.Title,
                Notes = consultancy.Notes,
                StatusId = (int)consultancy.Status,
                Status = consultancy.Status.ToString()
            };
            return ret;
        }

        public OrderDTO OrderToDTO(Order order)
        {
            var preparations = order.Preparations.Select(
                prep => new OrderPreparationDTO
                {
                    Id = prep.ResourceId,
                    Detail = prep.Detail,
                    Done = prep.Done
                }).ToList();

            return new OrderDTO
            {
                Status = order.OrderStatus.ToString(),
                StatusId = (long)order.OrderStatus,
                Id = order.ResourceId,
                ClientId = order.Consultancy?.Client?.SubjectId ?? 0,
                OrderMangerId = order.Consultancy?.Assignee?.SubjectId ?? 0,
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
