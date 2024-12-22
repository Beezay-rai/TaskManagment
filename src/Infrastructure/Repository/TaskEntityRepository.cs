using TaskManagement.Domain.Entities;
using TaskManagementApplication.Interfaces;
using TaskManagementInfrastructure.Data;

namespace TaskManagementInfrastructure.Repository
{
    public class TaskEntityRepository : GenericRepository<TaskEntity>, ITaskEntityRepository
    {
        public TaskEntityRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
