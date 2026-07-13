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
                Id = consultancy.ConsultancyId,
                Title = consultancy.Title,
                Notes = consultancy.Notes,
                StatusId = (int)consultancy.Status,
                Status = consultancy.Status.ToString()
            };
            return ret;
        }

        public OrderPreparationDTO OrderPreparationToDTO(OrderPreparation op)
        {
            return new OrderPreparationDTO
            {
                Id = op.OrderPreparationId,
                Detail = op.Detail,
                Done = op.Done,
                AssigneeId = op.AssigneeId ?? 0,
                OrderId = op.OrderId
            };
        }

        public List<OrderPreparationDTO> OrderPreparationToDTO(IEnumerable<OrderPreparation> ops)
        {
            return [.. ops.Select(op => OrderPreparationToDTO(op))];
        }

        public OrderDTO OrderToDTO(Order order)
        {
            return new OrderDTO
            {
                Status = order.OrderStatus.ToString(),
                StatusId = (long)order.OrderStatus,
                Id = order.OrderId,
                ClientId = order.Consultancy?.Client?.UserId ?? 0,
                OrderMangerId = order.Consultancy?.Assignee?.UserId ?? 0,
                Preparations = OrderPreparationToDTO(order.Preparations)
            };
        }

        public List<OrderDTO> OrderToDTO(IEnumerable<Order> orders)
        {
            var ret = orders.Select(o => OrderToDTO(o)).ToList();
            return ret;
        }

        public OrderTypeDTO OrderTypeToDTO(OrderType ot)
        {
            return new OrderTypeDTO
            {
                Id = ot.Id,
                Name = ot.Name
            };
        }

        public List<OrderTypeDTO> OrderTypeToDTO(IEnumerable<OrderType> ots)
        {
            return [.. ots.Select(ot => OrderTypeToDTO(ot))];
        }
    }
}
