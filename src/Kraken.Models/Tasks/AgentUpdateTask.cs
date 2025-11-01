namespace Kraken.Models.Tasks;

public class AgentUpdateTask : IAgentTask
{
    public Guid AgentId { get; set; }
    public static string Name => "AgentUpdateTask";
}