using MyMonkeyApp.Helpers;
using MyMonkeyApp.Models;

namespace MyMonkeyApp;

/// <summary>
/// Main program class for the Monkey Console Application
/// </summary>
public class Program
{
    /// <summary>
    /// Main entry point of the application
    /// </summary>
    /// <param name="args">Command line arguments</param>
    public static void Main(string[] args)
    {
        ShowWelcomeMessage();
        
        bool running = true;
        while (running)
        {
            ShowMenu();
            var choice = Console.ReadLine()?.Trim();
            
            switch (choice)
            {
                case "1":
                    ListAllMonkeys();
                    break;
                case "2":
                    GetMonkeyByName();
                    break;
                case "3":
                    GetRandomMonkey();
                    break;
                case "4":
                    running = false;
                    ShowGoodbyeMessage();
                    break;
                default:
                    Console.WriteLine("❌ Invalid choice. Please try again.\n");
                    break;
            }
            
            if (running)
            {
                Console.WriteLine("Press any key to continue...");
                try
                {
                    Console.ReadKey();
                }
                catch (InvalidOperationException)
                {
                    // Handle case when running in environments that don't support ReadKey
                    Console.ReadLine();
                }
                Console.Clear();
            }
        }
    }

    /// <summary>
    /// Displays the welcome message with ASCII art
    /// </summary>
    private static void ShowWelcomeMessage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
    🐵 Welcome to the Monkey Species Database! 🐵
    
       🐒    🙉    🙈    🙊    🐵
    ╭─────────────────────────────────────╮
    │     Explore the World of Primates   │
    ╰─────────────────────────────────────╯
        ");
        Console.ResetColor();
    }

    /// <summary>
    /// Displays the main menu options
    /// </summary>
    private static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╭─────────────────────────────────────╮");
        Console.WriteLine("│            MAIN MENU                │");
        Console.WriteLine("╰─────────────────────────────────────╯");
        Console.ResetColor();
        
        Console.WriteLine("1. 📋 List all monkey species");
        Console.WriteLine("2. 🔍 Find monkey by name");
        Console.WriteLine("3. 🎲 Get random monkey");
        Console.WriteLine("4. 🚪 Exit");
        Console.WriteLine();
        Console.Write("Please choose an option (1-4): ");
    }

    /// <summary>
    /// Lists all available monkey species
    /// </summary>
    private static void ListAllMonkeys()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🐵 All Monkey Species 🐵");
        Console.WriteLine("".PadRight(50, '='));
        Console.ResetColor();
        
        var monkeys = MonkeyHelper.GetAllMonkeys();
        
        for (int i = 0; i < monkeys.Count; i++)
        {
            var monkey = monkeys[i];
            Console.WriteLine($"{i + 1,2}. {monkey}");
        }
        
        Console.WriteLine($"\nTotal: {MonkeyHelper.GetMonkeyCount()} species");
        Console.WriteLine();
    }

    /// <summary>
    /// Prompts user for monkey name and displays detailed information
    /// </summary>
    private static void GetMonkeyByName()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("🔍 Find Monkey by Name 🔍");
        Console.WriteLine("".PadRight(50, '='));
        Console.ResetColor();
        
        Console.Write("Enter monkey name: ");
        var name = Console.ReadLine()?.Trim();
        
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("❌ Please enter a valid name.");
            return;
        }
        
        var monkey = MonkeyHelper.GetMonkeyByName(name);
        
        if (monkey != null)
        {
            DisplayMonkeyDetails(monkey);
        }
        else
        {
            Console.WriteLine($"❌ No monkey found with name: {name}");
            Console.WriteLine("\n💡 Tip: Try names like 'Chimpanzee', 'Orangutan', 'Gorilla', etc.");
        }
        
        Console.WriteLine();
    }

    /// <summary>
    /// Gets and displays a random monkey
    /// </summary>
    private static void GetRandomMonkey()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("🎲 Random Monkey Selection 🎲");
        Console.WriteLine("".PadRight(50, '='));
        Console.ResetColor();
        
        var monkey = MonkeyHelper.GetRandomMonkey();
        Console.WriteLine("🎉 Here's your random monkey:");
        Console.WriteLine();
        DisplayMonkeyDetails(monkey);
        Console.WriteLine();
    }

    /// <summary>
    /// Displays detailed information about a specific monkey
    /// </summary>
    /// <param name="monkey">The monkey to display details for</param>
    private static void DisplayMonkeyDetails(Monkey monkey)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"╭─ {monkey.Name} ─".PadRight(48, '─') + "╮");
        Console.ResetColor();
        
        Console.WriteLine($"📍 Location: {monkey.Location}");
        Console.WriteLine($"👥 Population: {monkey.Population:N0}");
        Console.WriteLine($"🛡️  Status: {monkey.ConservationStatus}");
        Console.WriteLine($"📖 Description: {monkey.Description}");
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("╰" + "".PadRight(46, '─') + "╯");
        Console.ResetColor();
    }

    /// <summary>
    /// Displays the goodbye message
    /// </summary>
    private static void ShowGoodbyeMessage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
    🐵 Thank you for exploring the monkey world! 🐵
    
    ╭─────────────────────────────────────╮
    │     See you later, primate friend!  │
    ╰─────────────────────────────────────╯
    
       🐒 Keep learning about wildlife! 🌿
        ");
        Console.ResetColor();
    }
}
