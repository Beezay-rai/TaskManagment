using FluentValidation;
using TaskManagementApplication.DTOs.TaskEntity;

namespace TaskManagementApplication.Features.TaskEntities.Commands.Create
{
    public class CreateTaskEntityValidator : AbstractValidator<CreateTaskEntityDTO>
    {
        public CreateTaskEntityValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage("{PropertyName} is required !")
               .NotNull()
               .MaximumLength(50)
               .WithMessage("{PropertyName} must not exceed 50 characters!");
        }
    }
}
