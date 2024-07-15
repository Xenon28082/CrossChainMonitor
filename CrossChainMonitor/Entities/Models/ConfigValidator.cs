namespace CrossChainMonitor.Models.Validators;

public class ConfigValidator{
    
    public static bool ValidateChainConfig(ChainConfiguration chainConfiguration){
            return chainConfiguration.Duration >= 0 && chainConfiguration.StartBlockNumber >= -1;
    }

}