using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace myNextApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSpaStaticFiles(config =>
            {
                config.RootPath = "../ClientApp";
            });

            var app = builder.Build();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "../ClientApp";
                spa.Options.PackageManagerCommand = "npm run dev";
                spa.UseProxyToSpaDevelopmentServer("http://localhost:3000"); // Use the correct URI here
            });
            app.Run();
        }
    }
}
   

