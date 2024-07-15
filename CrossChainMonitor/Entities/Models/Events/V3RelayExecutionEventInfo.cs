using System.Numerics;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace CrossChainMonitor.Events
{
    public partial class V3RelayExecutionEventInfo : V3RelayExecutionEventInfoBase { }

    public class V3RelayExecutionEventInfoBase 
    {
        [Parameter("address", "updatedRecipient", 1)]
        public virtual string? UpdatedRecipient { get; set; }
        [Parameter("bytes", "updatedMessage", 2)]
        public virtual byte[]? UpdatedMessage { get; set; }
        [Parameter("uint256", "updatedOutputAmount", 3)]
        public virtual BigInteger UpdatedOutputAmount { get; set; }
        [Parameter("uint8", "fillType", 4)]
        public virtual byte FillType { get; set; }
    }
}
