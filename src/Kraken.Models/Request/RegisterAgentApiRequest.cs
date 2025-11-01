using System.Runtime.InteropServices;

namespace Kraken.Shared.Request;

public class RegisterAgentApiRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string[]? Tags { get; set; }
    public string OperatingSystem { get; set; }
    public Guid[]? Environments { get; set; }
    public Architecture Architecture { get; set; }
}