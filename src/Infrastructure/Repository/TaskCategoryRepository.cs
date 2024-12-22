using TaskManagement.Domain.Entities;
using TaskManagementApplication.Interfaces;
using TaskManagementInfrastructure.Data;

namespace TaskManagementInfrastructure.Repository
{
    public class TaskCategoryRepository : GenericRepository<TaskCategory> ,ITaskCategoryRepository
    {
        public TaskCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
