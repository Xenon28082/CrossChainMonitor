
using CrossChainMonitor.Models;
using CrossChainMonitor.Utils;
using Microsoft.Extensions.Configuration;

namespace CrossChainMonitor.Logger;

public class MonitorStatusLogger : ILogger
{

    public void DoLog(object[] objs)
    {
        Console.WriteLine(StringUtils.PadBoth("CROSS CHAIN MONITOR", 189));
        foreach (var obj in objs)
        {
            var dictionary = (Dictionary<string, ChainConfiguration>)obj;
            foreach(var config in dictionary){
                Console.WriteLine(StringUtils.PadBoth(config.Value.ToString(), 189));
            }
        }
        Console.WriteLine("_________________________________________________________________________________________________________________________________________________________________________________________________________");
        Console.WriteLine("|    match id   | initiator | chain name |                          transaction hash                          |                  depositor                 |                  reciever                  |");
        Console.WriteLine("_________________________________________________________________________________________________________________________________________________________________________________________________________");

    }

}