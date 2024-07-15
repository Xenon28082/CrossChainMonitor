using CrossChainMonitor.Events;
using CrossChainMonitor.Logic;
using CrossChainMonitor.Models;
using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;

namespace CrossChainMonitor.Observers;

public class V3FundsDepositedObserver : IObserver{

    public void Observe(FilterLog log){
        
        var transitionEvent = log.DecodeEvent<V3FundsDepositedEventDTO>();
        if(transitionEvent != null){
            TransactionMatcher.TryAdd(transitionEvent.Event.DepositId, new SimpleTransaction("", log.TransactionHash, transitionEvent.Event.Depositor, transitionEvent.Event.Recipient, transitionEvent.Log.BlockNumber, true));
        }

    }

}