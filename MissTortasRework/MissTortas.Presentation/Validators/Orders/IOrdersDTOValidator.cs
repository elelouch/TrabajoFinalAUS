using FluentValidation;
using MissTortas.Presentation.DTO.Orders;

namespace MissTortas.Presentation.Validators.Orders
{
    public interface IOrdersDTOValidator
    {
        public IValidator<CreateOrderDTO> CreateOrderValidator();
        public IValidator<CreateOrderTypeDTO> CreateOrderTypeValidator();
        public IValidator<PlaceOrderDTO> PlaceOrderValidator();
    }
}
