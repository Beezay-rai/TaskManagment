using FluentValidation;
using TaskManagementApplication.DTOs.TaskCategory;

namespace TaskManagementApplication.Features.TaskCategories
{
    public class TaskCategoryValidator : AbstractValidator<TaskCategoryDTO>
    {
        public TaskCategoryValidator()
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
