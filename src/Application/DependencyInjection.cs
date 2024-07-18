using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TaskManagementApplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            
            services.AddMediatR(assembly);
            services.AddAutoMapper(assembly);
            services.AddValidatorsFromAssembly(assembly);
            

            return services;

        }
    }
}
