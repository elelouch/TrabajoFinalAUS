using FluentValidation;
using MissTortas.Presentation.DTO.Security;

namespace MissTortas.Presentation.Validators.Security
{
    public class UserModificationValidator : AbstractValidator<UserModification>
    {
        public int UsernameMinLength = 3;
        public int UsernameMaxLength = 256;

        public int EmailMinLength = 5;
        public int EmailMaxLength = 320;

        public int RoleMaxLength = 256;

        public UserModificationValidator()
        {
            RuleFor(user => user.Username)
                .NotEmpty()
                .Length(UsernameMinLength, UsernameMaxLength);

            RuleFor(user => user.Username)
                .Must(u => !string.IsNullOrWhiteSpace(u));

            RuleFor(user => user.Email)
                .Must(e => !string.IsNullOrWhiteSpace(e));

            RuleFor(user => user.Email)
                .NotEmpty()
                .Length(EmailMinLength, EmailMaxLength)
                .EmailAddress();

            RuleFor(user => user.Role)
                .MaximumLength(RoleMaxLength)
                .When(user => user.Role != null);
        }
    }
}