using FluentValidation;
using MissTortas.View.DTO.Security;

namespace MissTortas.View.Validators.Security
{
    public class CreateRoleRequestValidator : AbstractValidator<CreateRoleRequest>
    {
        public CreateRoleRequestValidator()
        {
            RuleFor(r => r.Name).NotEmpty().Length(3, 256);
        }
    }
}
