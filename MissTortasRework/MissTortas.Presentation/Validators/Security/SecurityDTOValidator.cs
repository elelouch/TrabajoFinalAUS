using FluentValidation;
using MissTortas.Presentation.DTO.Security;

namespace MissTortas.Presentation.Validators.Security
{
    public class SecurityDTOValidator(
        IValidator<UserModification> userModification
        )
        : ISecurityDTOValidator
    {
        public IValidator<UserModification> UserModificationValidator()
        {
            return userModification;
        }
    }
}