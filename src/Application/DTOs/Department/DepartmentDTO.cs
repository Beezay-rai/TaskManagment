using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Common;

namespace TaskManagementApplication.DTOs.Department
{
    public class DepartmentDTO : BaseEntity
    {
        public string Name { get; set; }
    }
    public class CreateDepartmentDTO
    {
        public string Name { get; set; }
    }

    public class EditDepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
