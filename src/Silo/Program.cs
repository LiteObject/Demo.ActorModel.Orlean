using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Silo
{
    /// <summary>
    /// Build the solution and run the Silo. 
    /// After you get the confirmation message that the Silo is running, run the Client.
    /// </summary>
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IHostBuilder builder = Host.CreateDefaultBuilder(args)
                                    .UseOrleans(silo =>
                                    {
                                        silo.UseLocalhostClustering()
                                            .ConfigureLogging(logging => logging.AddConsole());
                                    })
                                    .UseConsoleLifetime();

            using IHost host = builder.Build();

            await host.RunAsync();
        }
    }
}
