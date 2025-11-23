using Kraken.Models.Models;

namespace Kraken.Models.Tasks;

public class AgentDeploymentStepTask : IAgentTask
{
    public Guid DeploymentId { get; set; }
    public int StepOrder { get; set; }
    public string ScriptToExecute { get; set; } = string.Empty;
    public string ScriptSyntax { get; set; } = string.Empty;
    public string ReleaseVersion { get; set; } = string.Empty;

    /// <summary>
    ///     Project and Environment level variables
    /// </summary>
    public Dictionary<string, VariableValueModel> Variables { get; set; } = new();

    /// <summary>
    ///     Step template parameters with their values and control types
    /// </summary>
    public List<StepParameter> StepParameters { get; set; } = new();

    public StepTemplateVersionModel TemplateVersionModel { get; set; }
    public string Environment { get; set; } = string.Empty;
    public Guid AgentId { get; set; }

    public static string Name => "AgentStartDeploymentStepTask";
}

public class StepParameter
{
    public string Name { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string ControlType { get; set; } = string.Empty;

    /// <summary>
    ///     For SelectArtifact parameters: the artifact metadata
    /// </summary>
    public ArtifactMetadata? ArtifactMetadata { get; set; }
}

public class ArtifactMetadata
{
    public string Name { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string BasePath { get; set; } = string.Empty;
    public ArtifactAuthenticationConfig? Authentication { get; set; }
}

public class ArtifactAuthenticationConfig
{
    /// <summary>
    /// Authentication type: "internal", "none"
    /// </summary>
    public string Type { get; set; } = "none";
    
    /// <summary>
    /// Additional configuration for the authentication type
    /// For "jwt": uses agent's own token automatically
    /// For "basic": expects Username and Password
    /// For "apikey": expects ApiKey value
    /// </summary>
    public Dictionary<string, string>? Config { get; set; }
}