using Hangfire.PostgreSql;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Hangfire.Server
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            GlobalConfiguration.Configuration.UsePostgreSqlStorage(
                "Host=postgresql;Port=5432;User Id=postgres;Database=postgres;Password=123456;");
            var hostBuilder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                });
            using (var server = new BackgroundJobServer(new BackgroundJobServerOptions
            {
                WorkerCount = 1
            }))
            {
                await hostBuilder.RunConsoleAsync();
            }
        }
    }
}