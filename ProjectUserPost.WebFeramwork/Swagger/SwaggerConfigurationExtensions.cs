using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ProjectUserPost.Common.Utilities;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace ProjectUserPost.WebFeramwork.Swagger
{
    public static class SwaggerConfigurationExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            Assert.NotNull(services, nameof(services));

            services.AddSwaggerGen(options =>
            {

                options.EnableAnnotations();

                options.DescribeAllParametersInCamelCase();

                options.IgnoreObsoleteActions();

                options.IgnoreObsoleteProperties();

                options.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "API v1" });

                options.OperationFilter<RemoveVersionParameters>();

                options.DocumentFilter<SetVersionInPaths>();

                options.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                    var versions = methodInfo.DeclaringType
                        .GetCustomAttributes<ApiVersionAttribute>(true)
                        .SelectMany(attr => attr.Versions);

                    return versions.Any(v => $"v{v}" == docName);
                });
            });
        }

        public static void UseSwaggerAndUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Doc-V1");
            });
        }
    }
}
