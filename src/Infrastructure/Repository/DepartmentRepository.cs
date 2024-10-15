using TaskManagement.Domain.Entities;
using TaskManagementApplication.Interfaces;
using TaskManagementInfrastructure.Data;

namespace TaskManagementInfrastructure.Repository
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
