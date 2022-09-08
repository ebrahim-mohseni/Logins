using FluentValidation;
using Logins.Model.DTO;

namespace Logins.Client.Validator
{
	public class ChangePasswordValidator : AbstractValidator<ChangePasswordDto>
    {
        public ChangePasswordValidator()
        {
            RuleFor(p => p.Password).NotEmpty().WithMessage("You must enter a Password");
            RuleFor(p => p.ConfirmPassword).NotEmpty().WithMessage("You must enter a ConfirmPassword");
            RuleFor(p => p.ConfirmPassword).Equal(p => p.Password).WithMessage("Password not match");
        }
    }
}
