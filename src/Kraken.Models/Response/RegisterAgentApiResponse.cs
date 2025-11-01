using Kraken.Shared.Enums;

namespace Kraken.Shared.Response;

public record RegisterAgentApiResponse(
    Guid WorkspaceId,
    Guid AgentId,
    string? Name,
    string? Description,
    string[]? Tags,
    AgentStatus Status,
    string Version,
    string Slug,
    string OperatingSystem,
    string Architecture,
    string IpAddress,
    DateTimeOffset? LastSeen,
    Guid[] Environments,
    List<string>? EnvironmentNames)
{
    // NEW (nullable to avoid breaking old callers):
    public string? AuthUrl { get; init; }
    public string? AuthAccessToken { get; init; }
    public string? AuthRefreshToken { get; init; }
    public DateTimeOffset? AuthExpiresAt { get; init; }
}