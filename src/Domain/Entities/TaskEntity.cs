using System.ComponentModel.DataAnnotations.Schema;
using TaskManagement.Domain.Common;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Entities
{
    public sealed class TaskEntity: BaseAuditableEntity
    {
        public string Name { get; init; }
        public int TaskCategoryId { get; init; }
        public PriorityLevel PriorityLevel { get; init; }
        [ForeignKey(nameof(TaskCategoryId))]
        public TaskCategory TaskCategory { get; init; }
    }
}
