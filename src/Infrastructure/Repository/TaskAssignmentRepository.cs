using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagementApplication.Interfaces;

namespace TaskManagementInfrastructure.Repository
{
    public class TaskAssignmentRepository : ITaskAssignment
    {
        public Task<TaskAssignment> Create(TaskAssignment enitity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TaskAssignment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TaskAssignment> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(TaskAssignment enitity)
        {
            throw new NotImplementedException();
        }
    }
}
