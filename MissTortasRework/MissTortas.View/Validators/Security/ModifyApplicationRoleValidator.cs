using FluentValidation;
using MissTortas.View.DTO.Security;

namespace MissTortas.View.Validators.Security
{
    public class AssignPermissionToRoleValidator : AbstractValidator<ModifyApplicationRole>
    {
        public AssignPermissionToRoleValidator()
        {
            RuleFor(x => x.Permissions)
                .NotEmpty();

            RuleForEach(x => x.Permissions).Length(1, 256);
        }
    }
}