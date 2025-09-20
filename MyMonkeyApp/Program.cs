using MyMonkeyApp.Helpers;

namespace MyMonkeyApp;

/// <summary>
/// Main program class for the Monkey Console Application
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        ShowWelcomeMessage();
        RunMainMenu();
    }

    /// <summary>
    /// Displays the welcome message and ASCII art
    /// </summary>
    private static void ShowWelcomeMessage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
  __  __                 _                 
 |  \/  |               | |                
 | \  / | ___  _ __  ___| |__   ___  _ __  
 | |\/| |/ _ \| '_ \/ __| '_ \ / _ \| '_ \ 
 | |  | | (_) | | | \__ \ | | | (_) | | | |
 |_|  |_|\___/|_| |_|___/_| |_|\___/|_| |_|
                                            
   (\_/)  (monkey)
   (o.o)
  / >🍌
");
        Console.ResetColor();
        Console.WriteLine("Welcome to the Monkey Species Information System!");
        Console.WriteLine("Discover fascinating information about different monkey species.");
        Console.WriteLine();
    }

    /// <summary>
    /// Runs the main interactive menu loop
    /// </summary>
    private static void RunMainMenu()
    {
        bool continueRunning = true;

        while (continueRunning)
        {
            ShowMainMenu();
            var choice = GetUserChoice();

            switch (choice)
            {
                case "1":
                    ListAllMonkeys();
                    break;
                case "2":
                    ShowMonkeyDetailsByName();
                    break;
                case "3":
                    ShowRandomMonkey();
                    break;
                case "4":
                    continueRunning = false;
                    ShowGoodbyeMessage();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please enter 1, 2, 3, or 4.");
                    Console.ResetColor();
                    break;
            }

            if (continueRunning)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }

    /// <summary>
    /// Displays the main menu options
    /// </summary>
    private static void ShowMainMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("=== MONKEY SPECIES MENU ===");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("1) List all monkeys");
        Console.WriteLine("2) Show monkey details by name");
        Console.WriteLine("3) Show a random monkey");
        Console.WriteLine("4) Exit");
        Console.WriteLine();
        Console.Write("Please choose an option (1-4): ");
    }

    /// <summary>
    /// Gets user input choice
    /// </summary>
    /// <returns>The user's menu choice as a string</returns>
    private static string GetUserChoice()
    {
        return Console.ReadLine()?.Trim() ?? string.Empty;
    }

    /// <summary>
    /// Lists all available monkey species
    /// </summary>
    private static void ListAllMonkeys()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=== ALL MONKEY SPECIES ===");
        Console.ResetColor();
        Console.WriteLine();

        var monkeys = MonkeyHelper.GetMonkeys();
        if (!monkeys.Any())
        {
            Console.WriteLine("No monkey species data available.");
            return;
        }

        foreach (var monkey in monkeys)
        {
            DisplayMonkeyInfo(monkey);
            Console.WriteLine(new string('-', 50));
        }

        Console.WriteLine($"\nTotal species: {monkeys.Count()}");
    }

    /// <summary>
    /// Shows details for a specific monkey by name
    /// </summary>
    private static void ShowMonkeyDetailsByName()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=== FIND MONKEY BY NAME ===");
        Console.ResetColor();
        Console.WriteLine();
        
        Console.Write("Enter the monkey species name: ");
        var name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter a valid monkey name.");
            Console.ResetColor();
            return;
        }

        var monkey = MonkeyHelper.GetMonkeyByName(name);
        if (monkey == null)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"No monkey species found with the name '{name}'.");
            Console.WriteLine("\nAvailable species:");
            var allMonkeys = MonkeyHelper.GetMonkeys();
            foreach (var m in allMonkeys)
            {
                Console.WriteLine($"  - {m.Name}");
            }
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine();
            DisplayMonkeyInfo(monkey);
        }
    }

    /// <summary>
    /// Shows a randomly selected monkey species
    /// </summary>
    private static void ShowRandomMonkey()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=== RANDOM MONKEY SPECIES ===");
        Console.ResetColor();
        Console.WriteLine();

        try
        {
            var randomMonkey = MonkeyHelper.GetRandomMonkey();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("🎲 Here's a randomly selected monkey species:");
            Console.ResetColor();
            Console.WriteLine();
            DisplayMonkeyInfo(randomMonkey);
        }
        catch (InvalidOperationException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {ex.Message}");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Displays formatted information about a monkey species
    /// </summary>
    /// <param name="monkey">The monkey species to display</param>
    private static void DisplayMonkeyInfo(Models.Monkey monkey)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"🐒 {monkey.Name}");
        Console.ResetColor();
        
        Console.WriteLine($"📍 Location: {monkey.Location}");
        Console.WriteLine($"👥 Population: {monkey.Population:N0}");
        
        if (!string.IsNullOrWhiteSpace(monkey.Description))
        {
            Console.WriteLine($"📝 Description: {monkey.Description}");
        }
        
        Console.WriteLine();
    }

    /// <summary>
    /// Shows goodbye message when exiting
    /// </summary>
    private static void ShowGoodbyeMessage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Thanks for exploring the world of monkeys! 🐒");
        Console.WriteLine("Goodbye! 👋");
        Console.ResetColor();
    }
}
