using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Common;
using TaskManagement.Domain.Entities;
using TaskManagementInfrastructure.Data.Identity;
using TaskManagementInfrastructure.Library;

namespace TaskManagementInfrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, UserRole, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var user = _httpContextAccessor.HttpContext.User.Identity.Name;
            foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = user;
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = user;
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeletedBy = user;
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
        public DbSet<TaskAssignment> TaskAssignment { get; set; }
    }
}
