
using MyMonkeyApp.Helpers;
using MyMonkeyApp.Models;

namespace MyMonkeyApp;

internal class Program
{
    private static readonly string[] asciiArts = new[]
    {
        "  (\\__/)",
        "  (o.o )",
        "  (> < )",
        "  /\\_/\\",
        " ( ' . ' )",
        " (  .  .  )",
        " (  -  -  )",
        " (  @  @  )",
        " (  ^  ^  )",
        " (  =  =  )"
    };

    private static void PrintRandomAsciiArt()
    {
        var random = new Random();
        var art = asciiArts[random.Next(asciiArts.Length)];
        Console.WriteLine(art);
        Console.WriteLine();
    }

    private static void Main()
    {
        while (true)
        {
            PrintRandomAsciiArt();
            Console.WriteLine("Monkey Management Console");
            Console.WriteLine("1. List all monkeys");
            Console.WriteLine("2. Get details for a specific monkey by name");
            Console.WriteLine("3. Get a random monkey");
            Console.WriteLine("4. Exit app");
            Console.Write("Select an option: ");

            var userInput = Console.ReadLine();
            Console.WriteLine();

            switch (userInput)
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
                    Console.WriteLine("Exiting app. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.\n");
                    break;
            }
        }
    }

    private static void ListAllMonkeys()
    {
        var monkeys = MonkeyHelper.GetMonkeys();
        Console.WriteLine("All Monkeys:");
        foreach (var monkey in monkeys)
        {
            Console.WriteLine($"- {monkey.Name} ({monkey.Location}) - Population: {monkey.Population}");
        }
        Console.WriteLine();
    }

    private static void GetMonkeyByName()
    {
        Console.Write("Enter monkey name: ");
        var name = Console.ReadLine();
        var monkey = MonkeyHelper.GetMonkeyByName(name ?? string.Empty);
        if (monkey is not null)
        {
            PrintMonkeyDetails(monkey);
        }
        else
        {
            Console.WriteLine("Monkey not found.\n");
        }
    }

    private static void GetRandomMonkey()
    {
        var monkey = MonkeyHelper.GetRandomMonkey();
        PrintMonkeyDetails(monkey);
        Console.WriteLine($"Random monkey accessed {MonkeyHelper.GetRandomMonkeyAccessCount()} times.\n");
    }

    private static void PrintMonkeyDetails(Monkey monkey)
    {
        Console.WriteLine($"Name: {monkey.Name}");
        Console.WriteLine($"Location: {monkey.Location}");
        Console.WriteLine($"Population: {monkey.Population}");
        Console.WriteLine($"Details: {monkey.Details}");
        Console.WriteLine($"Image: {monkey.Image}");
        Console.WriteLine($"Latitude: {monkey.Latitude}");
        Console.WriteLine($"Longitude: {monkey.Longitude}");
        Console.WriteLine();
    }
}
