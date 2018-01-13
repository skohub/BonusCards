using BonusCards.Infrastructure.Configurations;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BonusCards.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            var services = host.Services;
            DbConfig.Initialize(services);
            AutomapperConfig.Configure();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
