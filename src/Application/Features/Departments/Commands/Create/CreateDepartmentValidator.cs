using FluentValidation;
using TaskManagementApplication.DTOs.Department;

namespace TaskManagementApplication.Features.Departments.Commands.Create
{
    public class EditTaskCategoryValidator : AbstractValidator<CreateDepartmentDTO>
    {
        public EditTaskCategoryValidator()
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
