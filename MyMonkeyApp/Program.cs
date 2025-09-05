using MyMonkeyApp.Art;
using MyMonkeyApp.Models;
using MyMonkeyApp.Services;

namespace MyMonkeyApp;

/// <summary>
/// Main program class for the Monkey Explorer console application.
/// </summary>
public class Program
{
    /// <summary>
    /// Main entry point of the application.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    public static void Main(string[] args)
    {
        try
        {
            RunApplication();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn unexpected error occurred: {ex.Message}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Runs the main application loop.
    /// </summary>
    private static void RunApplication()
    {
        DisplayWelcome();

        bool isRunning = true;
        while (isRunning)
        {
            DisplayMenu();
            var choice = GetUserChoice();

            switch (choice)
            {
                case 1:
                    DisplayAllMonkeys();
                    break;
                case 2:
                    SearchMonkeyByName();
                    break;
                case 3:
                    DisplayRandomMonkey();
                    break;
                case 0:
                    isRunning = false;
                    DisplayGoodbye();
                    break;
                default:
                    Console.WriteLine("\n❌ Invalid choice! Please select a number from the menu.");
                    break;
            }

            if (isRunning)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }

    /// <summary>
    /// Displays the welcome banner and introduction.
    /// </summary>
    private static void DisplayWelcome()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(MonkeyArt.Banner);
        Console.ResetColor();
        
        Console.WriteLine($"🌟 Discover amazing monkey species from around the world!");
        Console.WriteLine($"📊 Currently featuring {MonkeyHelper.GetMonkeyCount()} different species");
        Console.WriteLine();
    }

    /// <summary>
    /// Displays the main menu options.
    /// </summary>
    private static void DisplayMenu()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(MonkeyArt.Separator);
        Console.WriteLine("🐒 MONKEY EXPLORER - MAIN MENU");
        Console.WriteLine(MonkeyArt.Separator);
        Console.ResetColor();
        
        Console.WriteLine("1️⃣  List All Monkeys");
        Console.WriteLine("2️⃣  Search by Name");
        Console.WriteLine("3️⃣  Random Monkey");
        Console.WriteLine("0️⃣  Exit");
        Console.WriteLine();
        Console.Write("👉 Please select an option: ");
    }

    /// <summary>
    /// Gets and validates user menu choice.
    /// </summary>
    /// <returns>The validated menu choice, or -1 for invalid input.</returns>
    private static int GetUserChoice()
    {
        var input = Console.ReadLine()?.Trim();
        
        if (string.IsNullOrEmpty(input))
        {
            return -1;
        }

        return int.TryParse(input, out int choice) ? choice : -1;
    }

    /// <summary>
    /// Displays all monkey species in a formatted table.
    /// </summary>
    private static void DisplayAllMonkeys()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🐵 ALL MONKEY SPECIES");
        Console.WriteLine(MonkeyArt.Separator);
        Console.ResetColor();

        var monkeys = MonkeyHelper.GetMonkeys();
        
        if (monkeys.Count == 0)
        {
            Console.WriteLine("❌ No monkey species found in the database.");
            return;
        }

        Console.WriteLine($"{"Species Name".PadRight(25)} | {"Location".PadRight(20)} | Population");
        Console.WriteLine($"{new string('-', 25)} | {new string('-', 20)} | {new string('-', 15)}");

        foreach (var monkey in monkeys)
        {
            Console.WriteLine(monkey.ToString());
        }

        Console.WriteLine();
        Console.WriteLine($"✅ Total: {monkeys.Count} species found");
    }

    /// <summary>
    /// Searches for a monkey by name and displays the result.
    /// </summary>
    private static void SearchMonkeyByName()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("🔍 SEARCH MONKEY BY NAME");
        Console.WriteLine(MonkeyArt.Separator);
        Console.ResetColor();

        Console.Write("Enter monkey name to search: ");
        var searchName = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(searchName))
        {
            Console.WriteLine("❌ Please enter a valid monkey name.");
            return;
        }

        try
        {
            var monkey = MonkeyHelper.GetMonkeyByName(searchName);
            
            if (monkey != null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Monkey Found!");
                Console.ResetColor();
                Console.WriteLine(MonkeyArt.SmallMonkey);
                Console.WriteLine($"Name: {monkey.Name}");
                Console.WriteLine($"Location: {monkey.Location}");
                Console.WriteLine($"Population: {monkey.Population:N0}");
            }
            else
            {
                Console.WriteLine($"\n❌ No monkey species found with the name '{searchName}'.");
                Console.WriteLine("💡 Try searching for: Capuchin, Howler, Spider, or Proboscis");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Displays a randomly selected monkey species.
    /// </summary>
    private static void DisplayRandomMonkey()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("🎲 RANDOM MONKEY SELECTION");
        Console.WriteLine(MonkeyArt.Separator);
        Console.ResetColor();

        try
        {
            var randomMonkey = MonkeyHelper.GetRandomMonkey();
            
            Console.WriteLine("🎉 Here's your randomly selected monkey:");
            Console.WriteLine(MonkeyArt.HappyMonkey);
            Console.WriteLine($"🐒 Name: {randomMonkey.Name}");
            Console.WriteLine($"🌍 Location: {randomMonkey.Location}");
            Console.WriteLine($"👥 Population: {randomMonkey.Population:N0}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Displays the goodbye message when exiting the application.
    /// </summary>
    private static void DisplayGoodbye()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("👋 Thank you for using Monkey Explorer!");
        Console.WriteLine("🐒 Keep exploring the amazing world of primates!");
        Console.ResetColor();
        Console.WriteLine();
    }
}
