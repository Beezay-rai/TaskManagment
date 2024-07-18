using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApplication.Common;

namespace TaskManagementApplication.DTOs
{
    public class TaskAssignmentDTO:BaseDTO
    {
        public string Name { get; set; }
    }

    public class CreateTaskAssignmentDTO
    {
        public string Name { get; set; }
    }
}
