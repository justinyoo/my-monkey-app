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
            Name = "Chimpanzee",
            Location = "Central and West Africa",
            Population = 300000,
            Description = "Highly intelligent primates known for tool use and complex social structures",
            ConservationStatus = "Endangered"
        },
        new Monkey
        {
            Name = "Orangutan",
            Location = "Borneo and Sumatra",
            Population = 104000,
            Description = "Great apes known for their distinctive reddish hair and arboreal lifestyle",
            ConservationStatus = "Critically Endangered"
        },
        new Monkey
        {
            Name = "Gorilla",
            Location = "Central and Eastern Africa",
            Population = 200000,
            Description = "Largest living primates, gentle giants with impressive strength",
            ConservationStatus = "Critically Endangered"
        },
        new Monkey
        {
            Name = "Bonobo",
            Location = "Democratic Republic of Congo",
            Population = 50000,
            Description = "Peaceful apes closely related to chimpanzees, known for conflict resolution",
            ConservationStatus = "Endangered"
        },
        new Monkey
        {
            Name = "Macaque",
            Location = "Asia and North Africa",
            Population = 500000,
            Description = "Adaptable monkeys found in diverse habitats from forests to urban areas",
            ConservationStatus = "Least Concern"
        },
        new Monkey
        {
            Name = "Baboon",
            Location = "Africa and Arabia",
            Population = 800000,
            Description = "Large monkeys with dog-like faces living in complex social groups",
            ConservationStatus = "Least Concern"
        },
        new Monkey
        {
            Name = "Spider Monkey",
            Location = "Central and South America",
            Population = 100000,
            Description = "Acrobatic monkeys with long limbs and prehensile tails",
            ConservationStatus = "Vulnerable"
        },
        new Monkey
        {
            Name = "Howler Monkey",
            Location = "Central and South America",
            Population = 150000,
            Description = "Known for their loud vocalizations that can be heard for miles",
            ConservationStatus = "Least Concern"
        }
    };

    /// <summary>
    /// Gets all available monkey species
    /// </summary>
    /// <returns>A read-only list of all monkey species</returns>
    public static IReadOnlyList<Monkey> GetAllMonkeys()
    {
        return _monkeys.AsReadOnly();
    }

    /// <summary>
    /// Gets a specific monkey by name (case-insensitive)
    /// </summary>
    /// <param name="name">The name of the monkey to find</param>
    /// <returns>The monkey if found, otherwise null</returns>
    public static Monkey? GetMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        return _monkeys.FirstOrDefault(m => 
            m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets a random monkey from the collection
    /// </summary>
    /// <returns>A randomly selected monkey</returns>
    public static Monkey GetRandomMonkey()
    {
        var random = new Random();
        var index = random.Next(_monkeys.Count);
        return _monkeys[index];
    }

    /// <summary>
    /// Gets the total count of monkey species
    /// </summary>
    /// <returns>The number of monkey species in the collection</returns>
    public static int GetMonkeyCount()
    {
        return _monkeys.Count;
    }
}