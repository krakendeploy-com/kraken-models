using Kraken.Shared.Models;

namespace Kraken.Shared.Tasks;

public class AgentDeploymentStepTask : IAgentTask
{
    public Guid DeploymentId { get; set; }
    public int StepOrder { get; set; }
    public Guid AgentId { get; set; }
    public string ScriptToExecute { get; set; } = string.Empty;
    public string ScriptSyntax { get; set; } = string.Empty;
    public string ReleaseVersion { get; set; } = string.Empty;
    
    /// <summary>
    /// Project and Environment level variables
    /// </summary>
    public Dictionary<string, VariableValueModel> Variables { get; set; } = new();
    
    /// <summary>
    /// Step template parameters with their values and control types
    /// </summary>
    public List<StepParameter> StepParameters { get; set; } = new();
    
    public StepTemplateVersionModel TemplateVersionModel { get; set; }
    public string Environment { get; set; } = string.Empty;

    public static string Name => "AgentStartDeploymentStepTask";
}

public class StepParameter
{
    public string Name { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string ControlType { get; set; } = string.Empty;
    
    /// <summary>
    /// For SelectArtifact parameters: the artifact metadata
    /// </summary>
    public ArtifactMetadata? ArtifactMetadata { get; set; }
}

public class ArtifactMetadata
{
    public string Name { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string BasePath { get; set; } = string.Empty;
}



