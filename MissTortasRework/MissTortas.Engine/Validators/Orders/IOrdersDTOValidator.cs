using FluentValidation;
using MissTortas.Engine.DTO.Orders;

namespace MissTortas.Engine.Validators.Orders
{
    public interface IOrdersDTOValidator
    {
        public IValidator<CreateOrderDTO> CreateOrderValidator();
        public IValidator<CreateOrderTypeDTO> CreateOrderTypeValidator();
        public IValidator<PlaceOrderDTO> PlaceOrderValidator();
    }
}
