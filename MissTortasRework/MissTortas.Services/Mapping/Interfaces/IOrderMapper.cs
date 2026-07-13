using MissTortas.Domain.Orders;
using MissTortas.Services.DTO.Orders;

namespace MissTortas.Services.Mapping.Interfaces
{
    public interface IOrderMapper
    {
        public OrderTypeDTO OrderTypeToDTO(OrderType ot);
        public List<OrderTypeDTO> OrderTypeToDTO(IEnumerable<OrderType> ots);
        public OrderDTO OrderToDTO(Order order);
        public List<OrderDTO> OrderToDTO(IEnumerable<Order> orders);
        public ConsultancyDTO ConsultancyToDTO(Consultancy consultancy);
        public OrderPreparationDTO OrderPreparationToDTO(OrderPreparation op);
        public List<OrderPreparationDTO> OrderPreparationToDTO(IEnumerable<OrderPreparation> ops);
    }
}
