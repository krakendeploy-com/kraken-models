using Kraken.Models.Enums;

namespace Kraken.Models.Response;

public class AgentTaskResponse
{
    public AgentTaskType TaskType { get; set; }
    public object? Payload { get; set; }
}