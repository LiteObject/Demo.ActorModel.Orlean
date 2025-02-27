using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using GrainInterfaces;

namespace Client
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
                .UseOrleansClient(client =>
                {
                    client.UseLocalhostClustering();
                })
                .ConfigureLogging(logging => logging.AddConsole())
                .UseConsoleLifetime();

            using IHost host = builder.Build();
            await host.StartAsync();

            IClusterClient client = host.Services.GetRequiredService<IClusterClient>();

            IHello friend = client.GetGrain<IHello>(0);
            string response = await friend.SayHello("Hi friend!");

            Console.WriteLine($"""
                    {response}

                    Press any key to exit...
                    """);

            Console.ReadKey();

            await host.StopAsync();
        }
    }
}
