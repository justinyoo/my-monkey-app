namespace MyMonkeyApp.Models;

/// <summary>
/// Represents a monkey species with its basic information.
/// </summary>
public class Monkey
{
    /// <summary>
    /// Gets or sets the name of the monkey species.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the primary location where this monkey species is found.
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the estimated population of this monkey species.
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Monkey"/> class.
    /// </summary>
    public Monkey()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Monkey"/> class with specified values.
    /// </summary>
    /// <param name="name">The name of the monkey species.</param>
    /// <param name="location">The primary location of the species.</param>
    /// <param name="population">The estimated population.</param>
    public Monkey(string name, string location, int population)
    {
        Name = name;
        Location = location;
        Population = population;
    }

    /// <summary>
    /// Returns a string representation of the monkey.
    /// </summary>
    /// <returns>A formatted string containing the monkey's information.</returns>
    public override string ToString()
    {
        return $"{Name.PadRight(25)} | {Location.PadRight(20)} | Population: {Population:N0}";
    }
}