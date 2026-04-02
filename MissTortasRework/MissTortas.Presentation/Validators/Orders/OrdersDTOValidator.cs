using FluentValidation;
using MissTortas.Presentation.DTO.Orders;

namespace MissTortas.Presentation.Validators.Orders
{
    public class OrdersDTOValidator(
        IValidator<CreateOrder> createOrder,
        IValidator<PlaceOrder> placeOrder,
        IValidator<CreateOrderType> createOrderType
        )
        : IOrdersDTOValidator
    {
        public IValidator<CreateOrderType> CreateOrderTypeValidator()
        {
            return createOrderType;
        }

        public IValidator<CreateOrder> CreateOrderValidator()
        {
            return createOrder;
        }

        public IValidator<PlaceOrder> PlaceOrderValidator()
        {
            return placeOrder;
        }
    }
}
