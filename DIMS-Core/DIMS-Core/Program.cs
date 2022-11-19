using DIMS_Core.Logger.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace DIMS_Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration(config =>
                {
                    // Here we add file which contains configs for database. In this case it will be parsed and added in Configuration object.
                    config.AddJsonFile("database.json");
                })
                .UseCustomNLog();
        }
    }
}