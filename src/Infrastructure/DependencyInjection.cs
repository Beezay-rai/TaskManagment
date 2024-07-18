using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagementApplication.Interfaces;
using TaskManagementApplication.Models;
using TaskManagementInfrastructure.Data;
using TaskManagementInfrastructure.Data.Identity;
using TaskManagementInfrastructure.Library;
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
            services.Configure<AdministratorDetail>(options => configuration.Bind("AdministratorConfig", options));



            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IdentityProvider>();

            services.AddIdentity<ApplicationUser, UserRole>()
                .AddRoles<UserRole>()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddUserManager<UserManager<ApplicationUser>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<ApplicationDbContextInitializer>();

            #region Seeding Database

            using (var context = services.BuildServiceProvider().CreateScope())
            {
                var initialzer = context.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
                initialzer.SeedData().Wait();
            }

            #endregion

            #region Service Registration
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ITaskCategoryRepository, TaskCategoryRepository>();
            services.AddTransient<ITaskEntityRepository, TaskEntityRepository>();
            services.AddTransient<IAuthenticateRepository, AuthenticateRepository>();
            services.AddTransient<ITaskAssignment, TaskAssignmentRepository>();
            #endregion
            //Email Service Registration
            services.Configure<EmailSettingModel>(options => configuration.Bind("EmailSettings", new EmailSettingModel()));
            services.AddTransient<IEmailSender, EmailSender>();

            return services;

        }
    }
}
