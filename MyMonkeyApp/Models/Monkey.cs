namespace MyMonkeyApp.Models;

/// <summary>
/// Represents a monkey species with relevant details.
/// </summary>
public class Monkey
{
    /// <summary>
    /// Gets or sets the name of the monkey species.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the location where the monkey species is found.
    /// </summary>
    public required string Location { get; set; }

    /// <summary>
    /// Gets or sets the population count of the monkey species.
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// Gets or sets the detailed description of the monkey species.
    /// </summary>
    public string? Details { get; set; }

    /// <summary>
    /// Gets or sets the image URL of the monkey species.
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    /// Gets or sets the latitude of the monkey's habitat.
    /// </summary>
    public double? Latitude { get; set; }

    /// <summary>
    /// Gets or sets the longitude of the monkey's habitat.
    /// </summary>
    public double? Longitude { get; set; }
}
