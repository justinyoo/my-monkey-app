using MyMonkeyApp.Models;

namespace MyMonkeyApp.Services;

/// <summary>
/// Static helper class for managing monkey data
/// </summary>
public static class MonkeyHelper
{
    /// <summary>
    /// Static collection of monkey data
    /// </summary>
    private static readonly List<Monkey> _monkeys = new()
    {
        new Monkey
        {
            Name = "Proboscis Monkey",
            Location = "Borneo",
            Population = 7000,
            Details = "Known for their distinctive large nose and reddish-brown fur. They are excellent swimmers and live in mangrove forests.",
            AsciiArt = @"
    .-""""""-.
   /          \
  |  O      O  |
  |      <     |
  |     ___    |
   \           /
    '-.......-'
       |||||
    .-'     '-.
   /           \
  |  ~~~   ~~~  |
   \           /
    '-.......-'
"
        },
        new Monkey
        {
            Name = "Golden Snub-nosed Monkey",
            Location = "China",
            Population = 8000,
            Details = "Endangered species with beautiful golden fur. They live in mountainous regions and can survive harsh winters.",
            AsciiArt = @"
      .-""""""-.
     /          \
    |  ^      ^  |
    |     ..     |
    |    ____    |
     \  \    /  /
      '-.____.-'
         ||||
    .-.-.-.-.-.-.
   /               \
  |  ~~~     ~~~    |
   \               /
    '-.-.-.-.-.-.-.
"
        },
        new Monkey
        {
            Name = "Japanese Macaque",
            Location = "Japan",
            Population = 100000,
            Details = "Also known as snow monkeys, famous for bathing in hot springs during winter.",
            AsciiArt = @"
    .-""""""-.
   /          \
  |  o      o  |
  |      v     |
  |     ___    |
   \           /
    '-.......-'
       |||||
    .-'     '-.
   /  ~~~~~~~  \
  |     ___     |
   \           /
    '-.......-'
"
        },
        new Monkey
        {
            Name = "Mandrill",
            Location = "Central Africa",
            Population = 300000,
            Details = "World's largest monkey species. Males have colorful faces with blue and red markings.",
            AsciiArt = @"
    .-""""""-.
   /    /\    \
  |  O  ||  O  |
  |  |  ||  |  |
  |  |  ||  |  |
   \  \____/  /
    '-.......-'
       |||||
    .-'     '-.
   /  #######  \
  |  #  ###  #  |
   \  #######  /
    '-.......-'
"
        },
        new Monkey
        {
            Name = "Howler Monkey",
            Location = "Central and South America",
            Population = 500000,
            Details = "Known for their loud howling calls that can be heard up to 3 miles away. They spend most of their time in trees.",
            AsciiArt = @"
    .-""""""-.
   /    ^^    \
  |  O  ()  O  |
  |     ()     |
  |  \______/  |
   \  OOOOOO  /
    '-.......-'
       |||||
    .-'     '-.
   /  -------  \
  |  |  ___  |  |
   \  -------  /
    '-.......-'
"
        },
        new Monkey
        {
            Name = "Capuchin Monkey",
            Location = "Central and South America",
            Population = 50000,
            Details = "Highly intelligent primates often used in movies and shows. They use tools and have complex social structures.",
            AsciiArt = @"
    .-""""""-.
   /    ^^    \
  |  @      @  |
  |      )     |
  |     ~~~    |
   \           /
    '-.......-'
       |||||
    .-'     '-.
   /  *******  \
  |  * ##### *  |
   \  *******  /
    '-.......-'
"
        },
        new Monkey
        {
            Name = "Spider Monkey",
            Location = "Central and South America",
            Population = 25000,
            Details = "Extremely agile with long arms and legs. They swing through trees using their arms and prehensile tail.",
            AsciiArt = @"
    .-""""""-.
   /          \
  |  O      O  |
  |      ~     |
  |     ___    |
   \           /
    '-.......-'
       |||||
    .-'     '-.
   /  -------  \
  |  | ~~~~~ |  |
   \  -------  /
    '-.......-'
"
        },
        new Monkey
        {
            Name = "Vervet Monkey",
            Location = "Africa",
            Population = 500000,
            Details = "Small, intelligent monkeys with distinctive black faces. They live in large troops and have complex communication systems.",
            AsciiArt = @"
    .-""""""-.
   /    ##    \
  |  O  ##  O  |
  |  #  ##  #  |
  |  #  ##  #  |
   \  ######  /
    '-.......-'
       |||||
    .-'     '-.
   /  .......  \
  |  .  ...  .  |
   \  .......  /
    '-.......-'
"
        }
    };

    /// <summary>
    /// Gets all monkeys in the collection
    /// </summary>
    /// <returns>A list of all monkey objects</returns>
    public static List<Monkey> GetMonkeys()
    {
        return _monkeys;
    }

    /// <summary>
    /// Gets a monkey by its name (case-insensitive)
    /// </summary>
    /// <param name="name">The name of the monkey to find</param>
    /// <returns>The monkey object if found, null otherwise</returns>
    public static Monkey? GetMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        return _monkeys.FirstOrDefault(m => 
            m.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets a random monkey from the collection
    /// </summary>
    /// <returns>A random monkey object</returns>
    public static Monkey GetRandomMonkey()
    {
        Random random = new();
        int index = random.Next(_monkeys.Count);
        return _monkeys[index];
    }

    /// <summary>
    /// Gets the total count of monkeys in the collection
    /// </summary>
    /// <returns>The number of monkeys in the collection</returns>
    public static int GetMonkeyCount()
    {
        return _monkeys.Count;
    }
}