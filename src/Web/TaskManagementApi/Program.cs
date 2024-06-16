using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
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
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

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
                    ValidateIssuerSigningKey = true
                };

            });



            builder.Services.AddAuthorization();
            #endregion


            #region Api Services Registration
            builder.Services.AddSingleton<IUtility, TaskManagementApi.Utilities.Utility>();
            #endregion

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
            builder.Services.AddEndpointsApiExplorer();


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();



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
