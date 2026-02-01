using MissTortas.Data.Entity.Orders;
using MissTortas.Services.DTO.Order;

namespace MissTortas.Services.Mapper
{
    public interface IOrderMapper
    {
        public OrderTypeDTO OrderTypeToDTO(OrderType ot);
        public IEnumerable<OrderTypeDTO> OrderTypeToDTO(IEnumerable<OrderType> ots);
        public OrderDTO OrderToDTO(Order order);
    }
}
