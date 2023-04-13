using Microsoft.AspNetCore;
using ProjectUserPost.MyApi;

namespace MyApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
