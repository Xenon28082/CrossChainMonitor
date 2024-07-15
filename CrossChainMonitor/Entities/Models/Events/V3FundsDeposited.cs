using System.Numerics;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace CrossChainMonitor.Events;

public partial class V3FundsDepositedEventDTO : V3FundsDepositedEventDTOBase { }

[Event("V3FundsDeposited")]
public class V3FundsDepositedEventDTOBase : EventDTO
{
    [Parameter("address", "inputToken", 1, false)]
    public virtual string? InputToken { get; set; }
    [Parameter("address", "outputToken", 2, false)]
    public virtual string? OutputToken { get; set; }
    [Parameter("uint256", "inputAmount", 3, false)]
    public virtual BigInteger InputAmount { get; set; }
    [Parameter("uint256", "outputAmount", 4, false)]
    public virtual BigInteger OutputAmount { get; set; }
    [Parameter("uint256", "destinationChainId", 5, true)]
    public virtual BigInteger DestinationChainId { get; set; }
    [Parameter("uint32", "depositId", 6, true)]
    public virtual uint DepositId { get; set; }
    [Parameter("uint32", "quoteTimestamp", 7, false)]
    public virtual uint QuoteTimestamp { get; set; }
    [Parameter("uint32", "fillDeadline", 8, false)]
    public virtual uint FillDeadline { get; set; }
    [Parameter("uint32", "exclusivityDeadline", 9, false)]
    public virtual uint ExclusivityDeadline { get; set; }
    [Parameter("address", "depositor", 10, true)]
    public virtual string? Depositor { get; set; }
    [Parameter("address", "recipient", 11, false)]
    public virtual string? Recipient { get; set; }
    [Parameter("address", "exclusiveRelayer", 12, false)]
    public virtual string? ExclusiveRelayer { get; set; }
    [Parameter("bytes", "message", 13, false)]
    public virtual byte[]? Message { get; set; }
}