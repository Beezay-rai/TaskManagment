using TaskManagementApplication.Common;

namespace TaskManagementApplication.DTOs.TaskAssignment
{
    public class TaskAssignmentDTO : BaseDTO
    {
        public int UserId { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
        public string Remarks { get; set; }
    }
    public class CreateTaskAssignmentDTO
    {
        public int UserId { get; set; }
        public DateTime DueDate { get; set; }
        public string Remarks { get; set; }

    }
    public class EditTaskAssignmentDTO : BaseDTO
    {

        public int UserId { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }

        public string Remarks { get; set; }
    }
}
