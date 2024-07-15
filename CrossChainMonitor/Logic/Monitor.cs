using System.Numerics;
using CrossChainMonitor.Exceptions;
using CrossChainMonitor.Logger;
using CrossChainMonitor.Logic;
using CrossChainMonitor.Models;
using CrossChainMonitor.Models.Validators;
using CrossChainMonitor.Observers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Nethereum.Web3;

namespace CrossChainMonitor;

class Monitor : IHostedService
{

    private readonly Dictionary<string, ChainConfiguration> _chainsConfigs;

    private readonly IObserverFactory _observerFactory;

    public Monitor(IOptions<Dictionary<string, ChainConfiguration>> chainConfiguration, IObserverFactory observerFactory, ILogger logger)
    {
        _chainsConfigs = chainConfiguration.Value;
        _observerFactory = observerFactory;
        logger.DoLog([chainConfiguration.Value]);
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {

        await Parallel.ForEachAsync(_chainsConfigs, async (chainConfig, cancellationToken) =>
        {
            try
            {
                await Task.Run(async () =>
                    {

                        var web3 = new Web3(chainConfig.Value.Url);
                        var processor = web3.Processing.Logs.CreateProcessor(log =>
                        {
                            try
                            {
                                _observerFactory.CreateObserver(chainConfig.Value.Observers[0]).Observe(log);
                            }
                            catch (ObserverFactoryException exception)
                            {
                                Console.WriteLine(exception.Message);
                                throw new TaskCanceledException();
                            }
                        });


                        var latestBlock = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
                        if (!ConfigValidator.ValidateChainConfig(chainConfig.Value))
                        {
                            Console.WriteLine("Invalid configuration data: Duration can't be less than 0 and StartBlockNumber can't be less than -1");
                            throw new TaskCanceledException();
                        }

                        if (chainConfig.Value.StartBlockNumber == -1)
                        {
                            await processor.ExecuteAsync(
                                startAtBlockNumberIfNotProcessed: latestBlock,
                                waitInterval: chainConfig.Value.UpdateFrequency);
                        }
                        else
                        {
                            await processor.ExecuteAsync(
                                startAtBlockNumberIfNotProcessed: BigInteger.Min(chainConfig.Value.StartBlockNumber, latestBlock),
                                toBlockNumber: BigInteger.Min(chainConfig.Value.StartBlockNumber + chainConfig.Value.Duration, latestBlock),
                                cancellationToken: cancellationToken);
                        }
                    }, cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Thread for {0} ended with exception message: {1}", chainConfig.Key, ex.Message);
            }
        });

        TransactionMatcher.LogUnmatchedTransactions();
    }


    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

}