namespace Kraken.Shared.Models;

public class StepTemplateVersionModel
{
    public int Version { get; set; } = 1;
    public string Script { get; set; }
    public string? ScriptBody { get; set; }
    public string? Syntax { get; set; }
    public List<StepTemplateParameterModel>? Parameters { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}

public class StepTemplateParameterModel
{
    public string? Name { get; set; }
    public string? Label { get; set; }
    public string? HelpText { get; set; }
    public string? DefaultValue { get; set; }
    public string? ControlType { get; set; }
    public Dictionary<string, string?>? DisplaySettings { get; set; }
}