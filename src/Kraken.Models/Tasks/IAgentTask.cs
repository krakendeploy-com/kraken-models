namespace Kraken.Shared.Tasks;

public interface IAgentTask
{
    public Guid AgentId { get; set; }

    static abstract string Name { get; }
}