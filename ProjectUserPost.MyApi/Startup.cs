using PorjectUserPost.Services.Posts;
using PorjectUserPost.Services.Users;
using ProjectUserPost.Data.Posts;
using ProjectUserPost.Data.Posts.Cotracts;
using ProjectUserPost.Data.Users;
using ProjectUserPost.Data.Users.Contracts;
using ProjectUserPost.Data.Users.Contracts.Dtos;
using ProjectUserPost.Entities;
using ProjectUserPost.WebFeramwork.Configuration;
using ProjectUserPost.WebFeramwork.Middlewares;
using ProjectUserPost.WebFeramwork.Swagger;

namespace ProjectUserPost.MyApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<AddUserDto, User>();
                config.CreateMap<User, GetAllUserDto>();
                config.CreateMap<User, UserGetByIdDto>();
                config.CreateMap<EditUserDto, User>();
                config.CreateMap<User, GetForAddPost>();
            });
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("https://localhost:7193")
                              .WithMethods("PUT", "GET", "HEAD", "POST", "DELETE", "OPTIONS")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddDbContext(Configuration);

            services.AddMinimalMvc();

            services.AddCustomApiVersioning();

            services.AddSwagger();


            services.AddScoped<IPostRepository, EFPostRepository>();
            services.AddScoped<IPostService, PostAppService>();

            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<IUserService, UserAppService>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");

            app.IntializeDatabase();

            app.UseCustomExceptionHandler();

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
