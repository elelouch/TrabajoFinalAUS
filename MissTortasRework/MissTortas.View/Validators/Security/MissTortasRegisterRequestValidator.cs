using FluentValidation;
using MissTortas.View.DTO.Security;

namespace MissTortas.View.Validators.Security
{
    public class MissTortasRegisterRequestValidator : AbstractValidator<MissTortasRegisterRequest>
    {
        public MissTortasRegisterRequestValidator()
        {
            RuleFor(regReq => regReq.Email).NotEmpty().MaximumLength(256);
            RuleFor(regReq => regReq.Password).NotEmpty().MaximumLength(1024);
            RuleFor(regReq => regReq.FirstName).MaximumLength(256);
            RuleFor(regReq => regReq.LastName).MaximumLength(256);
        }
    }
}
