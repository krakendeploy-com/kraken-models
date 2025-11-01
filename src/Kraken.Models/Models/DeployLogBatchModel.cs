namespace Kraken.Shared.Models;

public class DeployLogBatchModel
{
    public Guid DeploymentId { get; set; }
    public int StepId { get; set; }
    public Guid AgentId { get; set; }
    public DeployLogType LogType { get; set; } = DeployLogType.Agent;
    public List<ScriptLogLineModel> Logs { get; set; } = [];
}

public enum DeployLogType
{
    Agent,
    Worker
}