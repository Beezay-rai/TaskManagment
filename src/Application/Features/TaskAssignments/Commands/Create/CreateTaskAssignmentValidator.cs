using FluentValidation;
using TaskManagementApplication.DTOs;

namespace TaskManagementApplication.Features.TaskAssignments.Commands.Create
{
    public class CreateTaskAssignmentValidator : AbstractValidator<CreateTaskAssignmentDTO>
    {
        public CreateTaskAssignmentValidator() 
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
