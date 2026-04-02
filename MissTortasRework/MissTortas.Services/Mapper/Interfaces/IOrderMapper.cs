using MissTortas.Domain.Orders;
using MissTortas.Services.DTO.Orders;

namespace MissTortas.Services.Mapper.Interfaces
{
    public interface IOrderMapper
    {
        public OrderTypeDTO OrderTypeToDTO(OrderType ot);
        public IEnumerable<OrderTypeDTO> OrderTypeToDTO(IEnumerable<OrderType> ots);
        public OrderDTO OrderToDTO(Order order);
        public ConsultancyDTO ConsultancyToDTO(Consultancy consultancy);
    }
}
