using FluentValidation;
using MissTortas.Presentation.DTO.Security;

namespace MissTortas.Presentation.Validators.Security
{
    public class SecurityDTOValidator(
        IValidator<UserModification> userModification,
        IValidator<AssignPermissionToRole> assignPermissionToRole

        )
        : ISecurityDTOValidator
    {
        public IValidator<UserModification> UserModificationValidator()
        {
            return userModification;
        }
        public IValidator<AssignPermissionToRole> AssignPermissionToRoleValidator()
        {
            return assignPermissionToRole;
        }
    }
}