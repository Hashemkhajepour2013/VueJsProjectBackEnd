using PorjectUserPost.Services.Posts;
using PorjectUserPost.Services.Users;
using ProjectUserPost.Data.Posts;
using ProjectUserPost.Data.Posts.Cotracts;
using ProjectUserPost.Data.Users;
using ProjectUserPost.Data.Users.Contracts;
using ProjectUserPost.WebFeramwork.Configuration;
using ProjectUserPost.WebFeramwork.Swagger;

namespace ProjectUserPost.MyApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext(Configuration);

            services.AddMinimalMvc();

            services.AddCustomApiVersioning();

            services.AddSwagger();


            services.AddScoped<IPostRepository, EFPostRepository>();
            services.AddScoped<IPostService, PostAppService>();

            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<IUserService, UserAppService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.IntializeDatabase();

            app.UseHsts(env);

            app.UseHttpsRedirection();

            app.UseSwaggerAndUI();

            app.UseRouting();

            app.UseAuthentication();

            app.UseEndpoints(config =>
            {
                config.MapControllers();
            });
        }
    }
}
