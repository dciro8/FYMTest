using FluentValidation;
using UserManager.Application.Models;

namespace UserManager.Application.Validations
{
    public class UserValidation : AbstractValidator<UserDto>
    {
        public UserValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().Must(x => x.Length > 0).MaximumLength(20);
            RuleFor(x => x.LastName).NotEmpty().Must(x => x.Length > 0).MaximumLength(100);
            RuleFor(x => x.DocumentNumber).NotEmpty().Must(x => x.Length > 0).MaximumLength(20);
            RuleFor(x => x.Email).NotEmpty().Must(x => x.Length > 0).MaximumLength(20);
        }
    }
}
