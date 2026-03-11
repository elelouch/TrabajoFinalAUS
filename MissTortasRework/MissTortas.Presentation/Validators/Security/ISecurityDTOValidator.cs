using FluentValidation;
using MissTortas.Presentation.DTO.Security;

namespace MissTortas.Presentation.Validators.Security
{
    public interface ISecurityDTOValidator
    {
        public IValidator<UserModification> UserModificationValidator();
    }
}
