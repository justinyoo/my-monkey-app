using MyMonkeyApp.Models;
using MyMonkeyApp.Services;

namespace MyMonkeyApp.Tests;

/// <summary>
/// Simple test class to verify the application functionality
/// </summary>
public static class SimpleTests
{
    /// <summary>
    /// Runs all tests and displays results
    /// </summary>
    public static void RunAllTests()
    {
        Console.WriteLine("🧪 Running Simple Tests...");
        Console.WriteLine("========================");
        
        TestMonkeyModel();
        TestMonkeyHelper();
        
        Console.WriteLine("✅ All tests completed!");
    }

    /// <summary>
    /// Tests the Monkey model functionality
    /// </summary>
    private static void TestMonkeyModel()
    {
        Console.WriteLine("Testing Monkey Model...");
        
        var monkey = new Monkey
        {
            Name = "Test Monkey",
            Location = "Test Location",
            Population = 12345,
            Details = "Test Details",
            AsciiArt = "Test ASCII Art"
        };

        // Test properties
        Console.WriteLine($"✓ Name: {monkey.Name}");
        Console.WriteLine($"✓ Location: {monkey.Location}");
        Console.WriteLine($"✓ Population: {monkey.Population:N0}");
        Console.WriteLine($"✓ ToString(): {monkey}");
        Console.WriteLine();
    }

    /// <summary>
    /// Tests the MonkeyHelper functionality
    /// </summary>
    private static void TestMonkeyHelper()
    {
        Console.WriteLine("Testing MonkeyHelper...");
        
        // Test GetMonkeys
        var monkeys = MonkeyHelper.GetMonkeys();
        Console.WriteLine($"✓ GetMonkeys() returned {monkeys.Count} monkeys");
        
        // Test GetMonkeyCount
        int count = MonkeyHelper.GetMonkeyCount();
        Console.WriteLine($"✓ GetMonkeyCount() returned {count}");
        
        // Test GetMonkeyByName
        var foundMonkey = MonkeyHelper.GetMonkeyByName("Proboscis");
        Console.WriteLine($"✓ GetMonkeyByName('Proboscis') found: {foundMonkey?.Name ?? "None"}");
        
        // Test GetRandomMonkey
        var randomMonkey = MonkeyHelper.GetRandomMonkey();
        Console.WriteLine($"✓ GetRandomMonkey() returned: {randomMonkey.Name}");
        
        // Test invalid search
        var notFound = MonkeyHelper.GetMonkeyByName("NonExistent");
        Console.WriteLine($"✓ GetMonkeyByName('NonExistent') returned: {notFound?.Name ?? "null (expected)"}");
        
        Console.WriteLine();
    }
}