using CrossChainMonitor.Utils;
using Nethereum.Hex.HexTypes;

namespace CrossChainMonitor.Models;

public class SimpleTransaction(string chainName, string transactionHash, string depositor, string reciever, HexBigInteger blockNumber, bool isInitiator)
{

    public string ChainName { get; } = chainName;

    public string TransactionHash { get; } = transactionHash;

    public string Depositor { get; } = depositor;

    public string Reciever { get; } = reciever;

    public HexBigInteger BlockNumber {get; } = blockNumber;

    public bool IsInitiator {get; } = isInitiator;

    public override string ToString(){
            return "|" + StringUtils.PadBoth(IsInitiator ? "input" : "output", 9) + " | " + StringUtils.PadBoth(ChainName, 12) + "| " + TransactionHash + " | " + Depositor + " | " + Reciever + " |" + BlockNumber;
        }
}