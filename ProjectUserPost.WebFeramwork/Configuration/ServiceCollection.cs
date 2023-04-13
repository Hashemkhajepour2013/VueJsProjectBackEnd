using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectUserPost.Data;

namespace ProjectUserPost.WebFeramwork.Configuration
{
    public static class ServiceCollection
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options
                    .UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });
        }

        public static void AddMinimalMvc(this IServiceCollection services)
        {
            services.AddControllers();
        }

        public static void AddCustomApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });
        }
    }
}
