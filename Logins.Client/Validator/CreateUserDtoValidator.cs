using FluentValidation;
using Logins.Model.DTO;

namespace Logins.Client.Validator
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage("You must enter a Email");
            RuleFor(p => p.Email).EmailAddress().WithMessage("You must enter a valid Email");
            RuleFor(p => p.Password).NotEmpty().WithMessage("You must enter a Password");
            RuleFor(p => p.ConfirmPassword).NotEmpty().WithMessage("You must enter a ConfirmPassword");
            RuleFor(p => p.ConfirmPassword).Equal(p => p.Password).WithMessage("Password not match");
            RuleFor(p => p.PositionId).NotEmpty().WithMessage("You must choose a Position");
            RuleFor(p => p.UserTypeId).NotEmpty().WithMessage("You must choose a UserType");
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("You must enter a FirstName");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("You must enter a LastName");
            RuleFor(p => p.BirthDate).NotEmpty().WithMessage("You must choose a Date for BirthDate");
            RuleFor(p => p.HireDate).NotEmpty().WithMessage("You must choose a Date for HireDate");
        }
    }
}
