using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagementApplication.Interfaces
{
    public interface ITaskAssignmentRepository:IGenericRepository<TaskAssignment>
    {
    }
}
