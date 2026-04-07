using FluentValidation;
using MissTortas.Presentation.DTO.Security;

namespace MissTortas.Presentation.Validators.Security
{
    public class AssignPermissionToRoleValidator : AbstractValidator<AssignPermissionToRole>
    {
        public AssignPermissionToRoleValidator()
        {
            RuleFor(x => x.Permissions)
                .NotEmpty();

            RuleForEach(x => x.Permissions).Length(1, 256);
        }
    }
}