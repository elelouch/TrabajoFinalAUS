using MissTortas.Domain.Orders;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.Mapping.Interfaces;
using MissTortas.Services.Repositories.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            return [.. ops.Select(OrderPreparationToDTO)];
        }

        public OrderPreparationDTO OrderPreparationToDTO(OrderPreparationDADto op)
        {
            return new OrderPreparationDTO
            {
                Id = op.Id,
                Detail = op.Detail,
                Done = op.Done,
                AssigneeId = op.AssigneeId
            };
        }

        public List<OrderPreparationDTO> OrderPreparationToDTO(IEnumerable<OrderPreparationDADto> ops)
        {
            return [.. ops.Select(OrderPreparationToDTO)];
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
            return [.. orders.Select(OrderToDTO)];
        }

        public OrderDTO OrderToDTO(OrderDADto dto)
        {
            return new OrderDTO
            {
                Id = dto.OrderId,
                Status = dto.OrderStatus.ToString(),
                StatusId = (long)dto.OrderStatus,
                PaymentStatus = dto.PaymentStatus.ToString(),
                Creation = dto.Creation,
                OrderMangerId = dto.OrderManagerId,
                ClientId = dto.ClientUserId,
                Preparations = OrderPreparationToDTO(dto.PreparationDADtos),
                SaleProducts = SaleProductToDTO(dto.SaleProductAskedDADtos)
            };
        }

        public List<OrderDTO> OrderToDTO(IEnumerable<OrderDADto> orders)
        {
            return [.. orders.Select(OrderToDTO)];
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
            return [.. ots.Select(OrderTypeToDTO)];
        }

        public SaleProductAskedDTO SaleProductToDTO(SaleProductAskedDADto source)
        {
            return new SaleProductAskedDTO
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                SalePrice = source.SalePrice,
                SaleQuantity = source.QuantityAsked
            };
        }

        public List<SaleProductAskedDTO> SaleProductToDTO(IEnumerable<SaleProductAskedDADto> saleProductDADto)
        {
            return [.. saleProductDADto.Select(SaleProductToDTO)];
        }
    }
}
