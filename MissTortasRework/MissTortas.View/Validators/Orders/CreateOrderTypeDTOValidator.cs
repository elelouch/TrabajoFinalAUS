using FluentValidation;
using MissTortas.View.DTO.Orders;

namespace MissTortas.View.Validators.Orders
{
    public class CreateOrderTypeDTOValidator : AbstractValidator<CreateOrderTypeRequest>
    {
        public int NameMinLength = 3;
        public int NameMaxLength = 256;
        public CreateOrderTypeDTOValidator()
        {
            RuleFor(ot => ot.Name).NotEmpty().MaximumLength(NameMaxLength).MinimumLength(NameMinLength);
        }
    }
}
