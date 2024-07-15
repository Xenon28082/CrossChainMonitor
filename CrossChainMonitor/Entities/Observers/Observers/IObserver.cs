using Nethereum.RPC.Eth.DTOs;

public interface IObserver
    {
        public void Observe(FilterLog log, string chainName);
    }