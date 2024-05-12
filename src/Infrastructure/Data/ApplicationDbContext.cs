using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Common;
using TaskManagement.Domain.Entities;
using TaskManagementInfrastructure.Data.Identity;

namespace TaskManagementInfrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,UserRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach(var entry in ChangeTracker.Entries<BaseAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeletedDate = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<TaskCategory> TaskCategory { get; set; }
        public DbSet<TaskEntity> TaskEntity { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
}
