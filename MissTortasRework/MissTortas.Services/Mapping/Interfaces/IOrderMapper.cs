using MissTortas.Domain.Orders;
using MissTortas.Services.DTO.Orders;

namespace MissTortas.Services.Mapping.Interfaces
{
    public interface IOrderMapper
    {
        public OrderTypeDTO OrderTypeToDTO(OrderType ot);
        public List<OrderTypeDTO> OrderTypeToDTO(IEnumerable<OrderType> ots);
        public OrderDTO OrderToDTO(Order order);
        public ConsultancyDTO ConsultancyToDTO(Consultancy consultancy);
    }
}
