using FluentValidation;
using MissTortas.Presentation.DTO.Security;

namespace MissTortas.Presentation.Validators.Security
{
    public class AssignPermissionToRoleValidator : AbstractValidator<AssignPermissionToRole>
    {
        public AssignPermissionToRoleValidator()
        {
            RuleFor(x => x.RoleId)
                .GreaterThan(0)
                .LessThan(long.MaxValue);

            RuleFor(x => x.Permissions)
                .NotEmpty();

            RuleForEach(x => x.Permissions)
                .GreaterThan(0)
                .LessThan(long.MaxValue);
        }
    }
}