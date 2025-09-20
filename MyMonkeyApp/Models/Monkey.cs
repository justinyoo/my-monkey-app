namespace MyMonkeyApp.Models;

/// <summary>
/// Represents a monkey species with basic information
/// </summary>
public class Monkey
{
    /// <summary>
    /// Gets or sets the name of the monkey species
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the primary location where this monkey species is found
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the estimated population of this monkey species
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// Gets or sets an optional description with additional details about the monkey species
    /// </summary>
    public string? Description { get; set; }
}