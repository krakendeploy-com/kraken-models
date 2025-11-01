using Kraken.Shared.Enums;

namespace Kraken.Shared.Response;

public class AgentTaskResponse
{
    public AgentTaskType TaskType { get; set; }
    public object? Payload { get; set; }
}