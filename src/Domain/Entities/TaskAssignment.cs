using TaskManagement.Domain.Common;

namespace TaskManagement.Domain.Entities
{
    public sealed class TaskAssignment:BaseAuditableEntity
    {
        public int UserId { get; init; }
        public DateTime DueDate { get; init; }   
        public bool IsComplete { get; init; } 
        public string Remarks { get; init; }

    }

    
}
