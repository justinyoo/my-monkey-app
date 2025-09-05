using MyMonkeyApp.Models;

namespace MyMonkeyApp.Services;

/// <summary>
/// Static helper class for managing monkey species data and operations.
/// </summary>
public static class MonkeyHelper
{
    /// <summary>
    /// Static collection of monkey species data.
    /// </summary>
    private static readonly List<Monkey> _monkeys = new()
    {
        new Monkey("Capuchin", "Central & South America", 250000),
        new Monkey("Howler Monkey", "South America", 150000),
        new Monkey("Spider Monkey", "Central America", 75000),
        new Monkey("Proboscis Monkey", "Borneo", 7000),
        new Monkey("Golden Snub-Nosed Monkey", "China", 15000),
        new Monkey("Mandrill", "Equatorial Africa", 20000),
        new Monkey("Japanese Macaque", "Japan", 50000),
        new Monkey("Gelada", "Ethiopia", 200000),
        new Monkey("Vervet Monkey", "East Africa", 500000),
        new Monkey("Rhesus Macaque", "Asia", 1000000),
        new Monkey("Baboon", "Africa & Arabia", 300000),
        new Monkey("Gibbon", "Southeast Asia", 30000)
    };

    /// <summary>
    /// Gets all monkey species in the collection.
    /// </summary>
    /// <returns>A read-only list of all monkey species, sorted by name.</returns>
    public static IReadOnlyList<Monkey> GetMonkeys()
    {
        return _monkeys.OrderBy(m => m.Name).ToList().AsReadOnly();
    }

    /// <summary>
    /// Finds a monkey species by name using case-insensitive comparison.
    /// </summary>
    /// <param name="name">The name of the monkey species to find.</param>
    /// <returns>The monkey species if found; otherwise, null.</returns>
    /// <exception cref="ArgumentException">Thrown when name is null or whitespace.</exception>
    public static Monkey? GetMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
        }

        return _monkeys.FirstOrDefault(m => 
            string.Equals(m.Name, name.Trim(), StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets a random monkey species from the collection.
    /// </summary>
    /// <returns>A randomly selected monkey species.</returns>
    /// <exception cref="InvalidOperationException">Thrown when no monkeys are available.</exception>
    public static Monkey GetRandomMonkey()
    {
        if (_monkeys.Count == 0)
        {
            throw new InvalidOperationException("No monkey species are available.");
        }

        var randomIndex = Random.Shared.Next(_monkeys.Count);
        return _monkeys[randomIndex];
    }

    /// <summary>
    /// Gets the total count of monkey species in the collection.
    /// </summary>
    /// <returns>The number of monkey species.</returns>
    public static int GetMonkeyCount()
    {
        return _monkeys.Count;
    }
}