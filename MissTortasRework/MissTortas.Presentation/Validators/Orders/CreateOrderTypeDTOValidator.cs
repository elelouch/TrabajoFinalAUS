using FluentValidation;
using MissTortas.Presentation.DTO.Orders;

namespace MissTortas.Presentation.Validators.Orders
{
    public class CreateOrderTypeDTOValidator : AbstractValidator<CreateOrderType>
    {
        public int NameMinLength = 3;
        public int NameMaxLength = 256;
        public CreateOrderTypeDTOValidator()
        {
            RuleFor(ot => ot.Name).NotEmpty().MaximumLength(NameMaxLength).MinimumLength(NameMinLength);
        }
    }
}
