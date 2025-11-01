namespace Kraken.Models.Models;

public class AgentRetentionPolicyModel
{
    /// <summary>
    ///     Number of deployed versions to retain per artifact.
    /// </summary>
    public int RetainDeployedVersions { get; set; } = 3;

    /// <summary>
    ///     Retain artifacts from the last X days, even if not deployed.
    /// </summary>
    public int RetainDays { get; set; } = 14;

    /// <summary>
    ///     Whether this policy is enabled.
    /// </summary>
    public bool Enabled { get; set; } = true;

    public string Environment { get; set; }
}