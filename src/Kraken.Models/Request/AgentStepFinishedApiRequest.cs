using Kraken.Shared.Enums;

namespace Kraken.Shared.Request;

public class AgentStepFinishedApiRequest
{
    public Guid DeploymentId { get; set; }
    public Guid AgentId { get; set; }
    public AgentStepStatus Status { get; set; }
    public string Logs { get; set; }
    public int StepId { get; set; }
}