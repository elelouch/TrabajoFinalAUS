using FluentValidation;
using MissTortas.Presentation.DTO.Orders;

namespace MissTortas.Presentation.Validators.Orders
{
    public class OrdersDTOValidator (
        IValidator<CreateOrderDTO> createOrder,
        IValidator<PlaceOrderDTO> placeOrder,
        IValidator<CreateOrderTypeDTO> createOrderType
        )
        : IOrdersDTOValidator
    {
        public IValidator<CreateOrderTypeDTO> CreateOrderTypeValidator()
        {
            return createOrderType;
        }

        public IValidator<CreateOrderDTO> CreateOrderValidator()
        {
            return createOrder;
        }

        public IValidator<PlaceOrderDTO> PlaceOrderValidator()
        {
            return placeOrder;
        }
    }
}
