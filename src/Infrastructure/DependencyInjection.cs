using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagementApplication.Interfaces;
using TaskManagementApplication.Models;
using TaskManagementInfrastructure.Data;
using TaskManagementInfrastructure.Data.Identity;
using TaskManagementInfrastructure.Repository;
using TaskManagementInfrastructure.Services;


namespace TaskManagementInfrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            var mssqlCon = configuration.GetConnectionString("MSSQlCon");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(mssqlCon);
            });

            services.AddIdentityCore<ApplicationUser>()
                .AddRoles<UserRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ITaskCategoryRepository, TaskCategoryRepository>();
            services.AddTransient<ITaskEntityRepository, TaskEntityRepository>();

            //Email Service Registration
            services.Configure<EmailSettingModel>(options => configuration.Bind("EmailSettings", new EmailSettingModel()));
            services.AddTransient<IEmailSender, EmailSender>();

            return services;

        }
    }
}
