using Kraken.Models.Enums;

namespace Kraken.Models.Request;

public class AgentNextTaskApiRequest
{
    public string Version { get; set; }
    public AgentStatus HealthStatus { get; set; }
    public AgentState TaskState { get; set; }
    public DateTime Timestamp { get; set; }

    public double CpuUsagePercent { get; set; }
    public double RamUsageMb { get; set; }
    public double DiskTotalGb { get; set; }
    public double DiskFreeGb { get; set; }
    public string? OsVersion { get; set; }
    public string? AgentUptime { get; set; }
    public string? IpAddress { get; set; }
}