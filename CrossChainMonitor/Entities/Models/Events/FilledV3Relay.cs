using System.Numerics;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace CrossChainMonitor.Events;

public partial class FilledV3RelayEventDTO : FilledV3RelayEventDTOBase { }

[Event("FilledV3Relay")]
    public class FilledV3RelayEventDTOBase : EventDTO
    {
        [Parameter("address", "inputToken", 1, false )]
        public virtual string? InputToken { get; set; }
        [Parameter("address", "outputToken", 2, false )]
        public virtual string? OutputToken { get; set; }
        [Parameter("uint256", "inputAmount", 3, false )]
        public virtual BigInteger InputAmount { get; set; }
        [Parameter("uint256", "outputAmount", 4, false )]
        public virtual BigInteger OutputAmount { get; set; }
        [Parameter("uint256", "repaymentChainId", 5, false )]
        public virtual BigInteger RepaymentChainId { get; set; }
        [Parameter("uint256", "originChainId", 6, true )]
        public virtual BigInteger OriginChainId { get; set; }
        [Parameter("uint32", "depositId", 7, true )]
        public virtual uint DepositId { get; set; }
        [Parameter("uint32", "fillDeadline", 8, false )]
        public virtual uint FillDeadline { get; set; }
        [Parameter("uint32", "exclusivityDeadline", 9, false )]
        public virtual uint ExclusivityDeadline { get; set; }
        [Parameter("address", "exclusiveRelayer", 10, false )]
        public virtual string? ExclusiveRelayer { get; set; }
        [Parameter("address", "relayer", 11, true )]
        public virtual string? Relayer { get; set; }
        [Parameter("address", "depositor", 12, false )]
        public virtual string? Depositor { get; set; }
        [Parameter("address", "recipient", 13, false )]
        public virtual string? Recipient { get; set; }
        [Parameter("bytes", "message", 14, false )]
        public virtual byte[]? Message { get; set; }
        [Parameter("tuple", "relayExecutionInfo", 15, false )]
        public virtual V3RelayExecutionEventInfo? RelayExecutionInfo { get; set; }
    }
