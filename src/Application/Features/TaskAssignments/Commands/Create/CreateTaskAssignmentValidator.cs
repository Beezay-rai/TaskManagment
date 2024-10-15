using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApplication.DTOs.TaskAssignment;

namespace TaskManagementApplication.Features.TaskAssignments.Commands.Create
{
    public class CreateTaskAssignmentValidator: AbstractValidator<CreateTaskAssignmentDTO>
    {
        public CreateTaskAssignmentValidator() 
        {
            RuleFor(x=>x.UserId).NotEmpty();
            RuleFor(x=>x.DueDate).NotEmpty();
        }
    }
}
