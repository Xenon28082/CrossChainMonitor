namespace CrossChainMonitor.Models;

public class ChainConfiguration
{
    public string Name { get; set; }
    public required string Url { get; set; }
    public int StartBlockNumber { get; set; }
    public List<string>? Observers { get; set; }
    public int Duration { get; set; }

    public int UpdateFrequency { get; set; }


    public override string ToString()
    {
        return StartBlockNumber == -1 ? "Monitoring: " + Name + " From lates block in real time" : "Monitoring: " + Name + " From block №: " + StartBlockNumber + " to block №: " + (StartBlockNumber + Duration);
    }
}
