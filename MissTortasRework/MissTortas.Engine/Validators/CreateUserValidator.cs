using FluentValidation;
using MissTortas.Engine.DTO;
using System.Text.RegularExpressions;

namespace MissTortas.Engine.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDTO>
    {
        public const int MinLengthPassword = 8;
        public const int MaxLengthPassword = 255;
        public const int MaxLengthUsername = 255;
        public const int MinLengthUsername = 6;
        public CreateUserValidator()
        {
            RuleFor(createUserDTO => createUserDTO.Password)
                .NotEmpty()
                .Length(MinLengthPassword, MaxLengthPassword)
                .Must(BeValidPassword);
            RuleFor(createUserDTO => createUserDTO.Email).NotEmpty().EmailAddress();
            RuleFor(createUserDTO => createUserDTO.Username)
                .NotEmpty()
                .Length(MinLengthUsername,MaxLengthUsername);
        }
        public bool BeValidPassword(string password)
        {
            var pattern = @"^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$";
            var regex = new Regex(pattern);
            return regex.IsMatch(password);
        }
    }
}
