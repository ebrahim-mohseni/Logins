using FluentValidation;
using Logins.Model.DTO;

namespace Logins.Client.Validator
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage("You must enter a Email");
            RuleFor(p => p.Email).EmailAddress().WithMessage("You must enter a valid Email");
            RuleFor(p => p.Password).NotEmpty().WithMessage("You must enter a Password");
        }
    }
}
