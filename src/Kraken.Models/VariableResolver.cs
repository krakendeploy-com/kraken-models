using System.Text.RegularExpressions;
using Kraken.Shared.Models;

namespace Kraken.Shared;

public class VariableResolver
{
    private readonly IReadOnlyDictionary<string, VariableValueModel> _variables;

    public VariableResolver(Dictionary<string, VariableValueModel> variables)
    {
        _variables = variables;
    }

    /// <summary>
    ///     Resolves variables in the provided script by recursively replacing any variable references
    ///     in the form $Kraken.Step.VarName, $Kraken.Project.VarName, $Kraken.Environment.VarName.
    /// </summary>
    /// <param name="script">The raw script to process and replace variables.</param>
    /// <returns>The script with variables replaced by their resolved values.</returns>
    public string ReplaceVariablesInScript(string script)
    {
        const int maxRecursionDepth = 5;
        var currentScript = script;

        for (var depth = 0; depth < maxRecursionDepth; depth++)
        {
            var changedThisPass = false;

            foreach (var kvp in _variables)
            {
                // match literal $ + key, avoid partials like $Kraken.Step.ScriptX
                var pattern = $@"\${Regex.Escape(kvp.Key)}(?![A-Za-z0-9_.])";
                var newScript = Regex.Replace(currentScript, pattern, m =>
                {
                    var resolvedValue = TryGetExactMatch(_variables, kvp.Key);
                    return resolvedValue ?? m.Value;
                });

                if (!ReferenceEquals(newScript, currentScript) && newScript != currentScript)
                {
                    currentScript = newScript;
                    changedThisPass = true;
                }
            }

            if (!changedThisPass) // whole pass made no changes → done
                break;
        }

        return currentScript;
    }


    /// <summary>
    ///     Try to get an exact match for the variable key from the dictionary.
    ///     Returns null if no exact match is found.
    /// </summary>
    private static string? TryGetExactMatch(IReadOnlyDictionary<string, VariableValueModel> dictionary, string key)
    {
        // Perform an exact match lookup (case-insensitive)
        if (dictionary.ContainsKey(key)) return dictionary[key].Value; // Return the value if exact match is found

        // If no match is found, return null
        return null;
    }
}