using CrossChainMonitor.Logger;
using CrossChainMonitor.Models;
using CrossChainMonitor.Observers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CrossChainMonitor;

class Program
{
    static async Task Main(string[] args){
        //Eth 20163848
        //Base 16235294
         var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: false).Build();

              await Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
            {
                services
                .AddSingleton<IConfiguration>(config)
                .AddSingleton<ILogger, MonitorStatusLogger>()
                .AddSingleton<IObserverFactory>(new ObserverFactory())
                .AddHostedService<Monitor>()
                .Configure<Dictionary<string, ChainConfiguration>>(config.GetSection("Chains"));
            }).RunConsoleAsync();

    }
}