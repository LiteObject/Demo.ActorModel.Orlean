using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Hosting;

Console.Title = "Bank Server";

// dotnet run --project BankServer
await Host.CreateDefaultBuilder()
    .UseOrleans(siloBuilder =>
    {
        siloBuilder
            .UseLocalhostClustering()
            .AddMemoryGrainStorageAsDefault()
            .UseTransactions();
    })
    .RunConsoleAsync();