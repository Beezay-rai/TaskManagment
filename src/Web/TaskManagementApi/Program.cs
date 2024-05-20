using TaskManagementApplication;
using TaskManagementInfrastructure;
namespace TaskManagementApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddApplicationServices()
                            .AddInfrastructure(builder.Configuration);


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("myClientApp", p =>
                {
                    p.WithOrigins("http://localhost:8088")
                    .AllowAnyHeader()

                    .AllowAnyMethod();
                });
                options.DefaultPolicyName = "myClientApp";
            });
            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("myClientApp");
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            app.MapAreaControllerRoute(
                  name: "areas",
                  areaName: "Admin",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

            app.Run();
        }
    }
}
