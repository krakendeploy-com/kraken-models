using Kraken.Models.Models;

namespace Kraken.Models.Tasks;

public class AgentCleanupTask : IAgentTask
{
    public List<AgentRetentionPolicyModel> RetentionPolicies { get; set; }
    public Guid AgentId { get; set; }
    public static string Name => "AgentCleanupTask";
}