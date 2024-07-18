using FluentValidation;
using TaskManagementApplication.Models;

namespace TaskManagementApplication.Features.Authenticate.Commands
{
    public class SignUpCommandValidator : AbstractValidator<SignUpModel>
    {
        public SignUpCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
