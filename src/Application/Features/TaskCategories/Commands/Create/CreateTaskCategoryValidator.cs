using FluentValidation;
using TaskManagementApplication.DTOs;

namespace TaskManagementApplication.Features.TaskCategories.Commands.Create
{
    public class CreateTaskCategoryValidator : AbstractValidator<CreateTaskCategoryDTO>
    {
        public CreateTaskCategoryValidator()
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
