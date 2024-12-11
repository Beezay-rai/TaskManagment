using System.ComponentModel.DataAnnotations.Schema;
using TaskManagement.Domain.Common;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Entities
{
    public sealed class TaskEntity: BaseAuditableEntity
    {
        public string Name { get; set; }
        public int TaskCategoryId { get; set; }
        public PriorityLevel PriorityLevel { get; set; }
        [ForeignKey(nameof(TaskCategoryId))]
        public TaskCategory TaskCategory { get; set; }
    }
}
