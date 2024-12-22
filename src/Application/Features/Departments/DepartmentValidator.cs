using FluentValidation;
using TaskManagementApplication.Common;
using TaskManagementApplication.DTOs.Department;

namespace TaskManagementApplication.Features.Departments
{
    public class DepartmentValidator<T> : AbstractValidator<T> where T : class
    {
        public DepartmentValidator()
        {

            if (typeof(T) == typeof(EditDepartmentDTO))
            {
                RuleFor(x => (x as EditDepartmentDTO).Name).NotEmpty();
            }

            if (typeof(T) == typeof(CreateDepartmentDTO))
            {
                RuleFor(x => (x as EditDepartmentDTO).Name).NotEmpty();
            }
        }
    }

}
