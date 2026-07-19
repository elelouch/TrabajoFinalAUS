using MissTortas.Domain.Orders;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.Repositories.DTO;

namespace MissTortas.Services.Mapping.Interfaces
{
    public interface IOrderMapper
    {
        public OrderTypeDTO OrderTypeToDTO(OrderType ot);
        public List<OrderTypeDTO> OrderTypeToDTO(IEnumerable<OrderType> ots);
        public OrderDTO OrderToDTO(OrderDADto order);
        public List<OrderDTO> OrderToDTO(IEnumerable<OrderDADto> order);
        public OrderDTO OrderToDTO(Order order);
        public List<OrderDTO> OrderToDTO(IEnumerable<Order> orders);
        public ConsultancyDTO ConsultancyToDTO(Consultancy consultancy);
        public OrderPreparationDTO OrderPreparationToDTO(OrderPreparation op);
        public OrderPreparationDTO OrderPreparationToDTO(OrderPreparationDADto op);
        public List<OrderPreparationDTO> OrderPreparationToDTO(IEnumerable<OrderPreparationDADto> op);
        public List<OrderPreparationDTO> OrderPreparationToDTO(IEnumerable<OrderPreparation> ops);
        public SaleProductAskedDTO SaleProductToDTO(SaleProductAskedDADto saleProductDADto);
        public List<SaleProductAskedDTO> SaleProductToDTO(IEnumerable<SaleProductAskedDADto> saleProductDADto);

    }
}
