using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Common;

namespace TaskManagement.Domain.Entities
{
    public class TaskAssignment:BaseAuditableEntity
    {
        public int UserId { get; set; }
        public DateTime DueDate { get; set; }   
        public bool IsComplete { get; set; } 
        public string Remarks { get; set; }

    }

    
}
