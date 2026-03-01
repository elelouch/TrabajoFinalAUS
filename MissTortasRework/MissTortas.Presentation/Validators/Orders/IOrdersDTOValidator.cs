using FluentValidation;
using MissTortas.Presentation.DTO.Orders;

namespace MissTortas.Presentation.Validators.Orders
{
    public interface IOrdersDTOValidator
    {
        public IValidator<CreateOrder> CreateOrderValidator();
        public IValidator<CreateOrderType> CreateOrderTypeValidator();
        public IValidator<PlaceOrder> PlaceOrderValidator();
    }
}
