using FluentValidation;
using TaskManagementApplication.Models;

namespace TaskManagementApplication.Features.Authenticate.Commands
{
    public class LoginCommandValidator : AbstractValidator<LoginModel>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Username)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
