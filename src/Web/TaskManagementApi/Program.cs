using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Core;
using System.Text;
using TaskManagementApi.Library.ChatHub;
using TaskManagementApi.Utilities;
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

            builder.Services.AddApplicationServices()
                            .AddInfrastructure(builder.Configuration);


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("myClientApp", p =>
                {
                    p.WithOrigins("http://localhost:8088")
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .AllowAnyMethod();
                });
                options.DefaultPolicyName = "myClientApp";
            });

            #region Logging Configure
          
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .WriteTo.Console()
                .WriteTo.File("Logs/logs-.txt",rollingInterval:RollingInterval.Day)
                .CreateLogger()
                );
            #endregion


            #region Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.RequireAuthenticatedSignIn = true;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidAudience = builder.Configuration["JWTConfig:ValidAudience"],
                    ValidateAudience = true,
                    ValidIssuer = builder.Configuration["JWTConfig:ValidIssuer"],
                    ValidateIssuer = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTConfig:SecretKey"])),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime= true
                };

            });

            builder.Services.AddAuthorization();
            #endregion


            #region Api Services Registration
            builder.Services.AddSingleton<IUtility, TaskManagementApi.Utilities.Utility>();
            builder.Services.AddSignalR();
            #endregion
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Jwt Authentication with Bearer",
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme,
                            }
                        }, new List<string>()
                    }
                });
            });


            var app = builder.Build();
            app.Logger.LogInformation("App Initialized !");

            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCors("myClientApp");
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapHub<ChatHub>("/chatHub");

          


         
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
