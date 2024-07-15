using System.Collections.Concurrent;
using CrossChainMonitor.Logger;
using CrossChainMonitor.Models;
using CrossChainMonitor.Utils;

namespace CrossChainMonitor.Logic;

public class TransactionMatcher
{

    private static readonly ConcurrentDictionary<uint, SimpleTransaction> _transactions = new();

    private static readonly TransactionsLogger _logger = new();

    public static void TryAdd(uint depositId, SimpleTransaction transaction)
    {
        if (!_transactions.TryAdd(depositId, transaction))
        {
            SimpleTransaction alreadyFoundTransaction = _transactions[depositId];
             
            _logger.DoLog([alreadyFoundTransaction, transaction]);
            TryRemove(depositId, alreadyFoundTransaction);
        }
    }

    private static void TryRemove(uint depositId, SimpleTransaction alreadyFoundTransaction){
        _transactions.TryRemove(new KeyValuePair<uint, SimpleTransaction>(depositId, alreadyFoundTransaction));
    }

    public static void LogUnmatchedTransactions(){
        Console.WriteLine("|" + StringUtils.PadBoth("Unmatched transactions", 187) + "|");
        foreach(var transaction in _transactions.Values){
         _logger.DoLog([transaction]);
        }
    }

}