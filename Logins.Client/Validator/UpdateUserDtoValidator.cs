using FluentValidation;
using Logins.Model.DTO;

namespace Logins.Client.Validator
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(p => p.UserTypeId).NotEmpty().WithMessage("You must choose a UserType");
            RuleFor(p => p.PositionId).NotEmpty().WithMessage("You must choose a Positon");
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("You must enter a FirstName");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("You must enter a LastName");
            RuleFor(p => p.BirthDate).NotEmpty().WithMessage("You must choose a Date for BirthDate");
            RuleFor(p => p.HireDate).NotEmpty().WithMessage("You must choose a Date for HireDate");
        }
    }
}
