using FluentValidation;
using MissTortas.Engine.DTO.Orders;

namespace MissTortas.Engine.Validators.Orders
{
    public class CreateOrderTypeDTOValidator : AbstractValidator<CreateOrderTypeDTO>
    {
        public int NameMinLength = 3;
        public int NameMaxLength = 256;
        public CreateOrderTypeDTOValidator()
        {
            RuleFor(ot => ot.Name).NotEmpty().MaximumLength(NameMaxLength).MinimumLength(NameMinLength);
        }
    }
}
