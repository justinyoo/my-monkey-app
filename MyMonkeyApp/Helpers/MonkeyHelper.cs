using MyMonkeyApp.Models;

namespace MyMonkeyApp.Helpers;

/// <summary>
/// Static helper class for managing monkey species data
/// </summary>
public static class MonkeyHelper
{
    private static readonly List<Monkey> _monkeys = new()
    {
        new Monkey 
        { 
            Name = "Bonobos", 
            Location = "Democratic Republic of Congo", 
            Population = 50000,
            Description = "Peaceful and intelligent great apes known for their social behavior"
        },
        new Monkey 
        { 
            Name = "Golden Snub-nosed Monkey", 
            Location = "China", 
            Population = 8000,
            Description = "Endangered monkeys with distinctive golden fur and upturned noses"
        },
        new Monkey 
        { 
            Name = "Japanese Macaque", 
            Location = "Japan", 
            Population = 120000,
            Description = "Also known as snow monkeys, famous for bathing in hot springs"
        },
        new Monkey 
        { 
            Name = "Proboscis Monkey", 
            Location = "Borneo", 
            Population = 7000,
            Description = "Distinguished by their large noses and reddish-brown fur"
        },
        new Monkey 
        { 
            Name = "Howler Monkey", 
            Location = "Central and South America", 
            Population = 100000,
            Description = "Known for their loud howls that can be heard up to 3 miles away"
        },
        new Monkey 
        { 
            Name = "Spider Monkey", 
            Location = "Central and South America", 
            Population = 80000,
            Description = "Agile primates with long limbs and prehensile tails"
        },
        new Monkey 
        { 
            Name = "Mandrill", 
            Location = "Equatorial Africa", 
            Population = 25000,
            Description = "Colorful primates with distinctive facial coloring, especially in males"
        }
    };

    /// <summary>
    /// Gets all available monkey species
    /// </summary>
    /// <returns>An enumerable collection of all monkey species</returns>
    public static IEnumerable<Monkey> GetMonkeys()
    {
        return _monkeys.AsReadOnly();
    }

    /// <summary>
    /// Finds a monkey species by name (case-insensitive)
    /// </summary>
    /// <param name="name">The name of the monkey species to find</param>
    /// <returns>The monkey species if found, otherwise null</returns>
    public static Monkey? GetMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        var trimmedName = name.Trim();
        return _monkeys.FirstOrDefault(m => 
            string.Equals(m.Name, trimmedName, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets a random monkey species from the available collection
    /// </summary>
    /// <returns>A randomly selected monkey species</returns>
    public static Monkey GetRandomMonkey()
    {
        if (_monkeys.Count == 0)
            throw new InvalidOperationException("No monkeys available");

        var random = new Random();
        var index = random.Next(_monkeys.Count);
        return _monkeys[index];
    }
}