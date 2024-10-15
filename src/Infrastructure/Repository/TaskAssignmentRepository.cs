using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagementApplication.Interfaces;
using TaskManagementInfrastructure.Data;

namespace TaskManagementInfrastructure.Repository
{
    public class TaskAssignmentRepository : GenericRepository<TaskAssignment>, ITaskAssignmentRepository
    {
        public TaskAssignmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
