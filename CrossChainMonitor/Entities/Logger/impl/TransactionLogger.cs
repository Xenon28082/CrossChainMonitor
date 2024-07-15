using CrossChainMonitor.Utils;

namespace CrossChainMonitor.Logger;

public class TransactionsLogger : ILogger
{

    private static int RecordId = 0;

    public void DoLog(object[] objs)
    {
        ++RecordId;
        foreach (var obj in objs)
        {       
            Console.WriteLine("|" + StringUtils.PadBoth(RecordId.ToString(), 15) + obj);
        }
        Console.WriteLine("_____________________________________________________________________________________________________________________________________________________________________________________________");
    }
}