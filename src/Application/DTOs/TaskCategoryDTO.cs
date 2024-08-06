using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApplication.Common;

namespace TaskManagementApplication.DTOs
{
    public class TaskCategoryDTO:BaseDTO
    {
        public string Name { get; set; }
    }

    public class CreateTaskCategoryDTO
    {
        public string Name { get; set; }
    }

    public class EditTaskCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
