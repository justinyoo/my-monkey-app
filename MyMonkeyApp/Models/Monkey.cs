namespace MyMonkeyApp.Models;

/// <summary>
/// Represents a monkey species with its characteristics and information
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
    /// Gets or sets a brief description of the monkey species
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the conservation status of the monkey species
    /// </summary>
    public string ConservationStatus { get; set; } = string.Empty;

    /// <summary>
    /// Returns a string representation of the monkey
    /// </summary>
    /// <returns>A formatted string with monkey information</returns>
    public override string ToString()
    {
        return $"{Name} - {Location} (Population: {Population:N0})";
    }
}