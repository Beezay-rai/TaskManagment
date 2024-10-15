using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Common;
using TaskManagement.Domain.Enums;

namespace TaskManagementApplication.DTOs.TaskEntity
{
    public class TaskEntityDTO : BaseAuditableEntity
    {
        public string Name { get; set; }
        public int TaskCategoryId { get; set; }
        public PriorityLevel PriorityLevel { get; set; }
    }

    public class CreateTaskEntityDTO
    {
        public string Name { get; set; }
        public int TaskCategoryId { get; set; }
        public PriorityLevel PriorityLevel { get; set; }
    }
}
