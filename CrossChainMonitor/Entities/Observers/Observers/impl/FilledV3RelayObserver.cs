using CrossChainMonitor.Events;
using CrossChainMonitor.Logic;
using CrossChainMonitor.Models;
using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;

namespace CrossChainMonitor.Observers;

public class FilledV3RelayObserver : IObserver
{
    public void Observe(FilterLog log)
    {
        var transitionEvent = log.DecodeEvent<FilledV3RelayEventDTO>();
        if (transitionEvent != null)
        {
            TransactionMatcher.TryAdd(transitionEvent.Event.DepositId, new SimpleTransaction("etherium", log.TransactionHash, transitionEvent.Event.Depositor, transitionEvent.Event.Recipient, transitionEvent.Log.BlockNumber, false));
        }
    }
}