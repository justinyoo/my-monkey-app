using MyMonkeyApp.Services;
using MyMonkeyApp.Tests;

namespace MyMonkeyApp;

/// <summary>
/// Main program entry point for the Monkey App
/// </summary>
class Program
{
    /// <summary>
    /// Main method - entry point of the application
    /// </summary>
    /// <param name="args">Command line arguments</param>
    static void Main(string[] args)
    {
        try
        {
            // Set console encoding to support Unicode characters
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            // Check if user wants to run tests
            if (args.Length > 0 && args[0].ToLower() == "test")
            {
                SimpleTests.RunAllTests();
                return;
            }
            
            // Check if user wants to run in demo mode
            if (args.Length > 0 && args[0].ToLower() == "demo")
            {
                RunDemoMode();
                return;
            }
            
            // Show welcome message
            ShowWelcomeMessage();
            
            // Start the main menu
            ConsoleUI.ShowMainMenu();
            
            // Show goodbye message
            ShowGoodbyeMessage();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"애플리케이션 실행 중 오류가 발생했습니다: {ex.Message}");
            Console.ResetColor();
            Console.WriteLine("Press any key to exit...");
            if (Console.IsInputRedirected)
            {
                Console.ReadLine();
            }
            else
            {
                Console.ReadKey();
            }
        }
    }

    /// <summary>
    /// Runs the application in demo mode for screenshots
    /// </summary>
    private static void RunDemoMode()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
    🐵 ================================== 🐵
         원숭이 정보 시스템에 오신 것을 환영합니다!
    🐵 ================================== 🐵
        ");
        Console.ResetColor();
        Console.WriteLine("이 프로그램은 다양한 원숭이 종류에 대한 정보를 제공합니다.");
        Console.WriteLine("메뉴를 선택하여 원숭이들의 정보를 확인해보세요!");
        Console.WriteLine();
        
        // Show main menu
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("🐵 =============================================");
        Console.WriteLine("    MY MONKEY APP - 원숭이 정보 시스템");
        Console.WriteLine("🐵 =============================================");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("📋 메뉴를 선택하세요:");
        Console.WriteLine("1. 모든 원숭이 리스트 보기");
        Console.WriteLine("2. 원숭이 이름으로 검색");
        Console.WriteLine("3. 랜덤 원숭이 보기");
        Console.WriteLine("4. 원숭이 총 개수 보기");
        Console.WriteLine("5. 종료");
        Console.WriteLine();
        
        // Show all monkeys list
        Console.WriteLine("=== 1번 선택: 모든 원숭이 리스트 ===");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🐵 모든 원숭이 리스트");
        Console.WriteLine("===================");
        Console.ResetColor();
        
        var monkeys = MonkeyHelper.GetMonkeys();
        for (int i = 0; i < monkeys.Count; i++)
        {
            var monkey = monkeys[i];
            Console.WriteLine($"{i + 1}. {monkey}");
        }
        
        Console.WriteLine();
        Console.WriteLine("자세한 정보를 보려면 원숭이 이름으로 검색해보세요!");
        Console.WriteLine();
        
        // Show a random monkey
        Console.WriteLine("=== 3번 선택: 랜덤 원숭이 ===");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("🎲 랜덤 원숭이");
        Console.WriteLine("=============");
        Console.ResetColor();
        
        var randomMonkey = MonkeyHelper.GetRandomMonkey();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"🐵 {randomMonkey.Name}");
        Console.WriteLine(new string('=', randomMonkey.Name.Length + 3));
        Console.ResetColor();
        
        Console.WriteLine($"📍 서식지: {randomMonkey.Location}");
        Console.WriteLine($"👥 개체 수: {randomMonkey.Population:N0}마리");
        Console.WriteLine($"ℹ️  정보: {randomMonkey.Details}");
        
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("ASCII 아트:");
        Console.WriteLine(randomMonkey.AsciiArt);
        Console.ResetColor();
    }

    /// <summary>
    /// Displays the welcome message
    /// </summary>
    private static void ShowWelcomeMessage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
    🐵 ================================== 🐵
         원숭이 정보 시스템에 오신 것을 환영합니다!
    🐵 ================================== 🐵
        ");
        Console.ResetColor();
        Console.WriteLine("이 프로그램은 다양한 원숭이 종류에 대한 정보를 제공합니다.");
        Console.WriteLine("메뉴를 선택하여 원숭이들의 정보를 확인해보세요!");
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        if (Console.IsInputRedirected)
        {
            Console.ReadLine();
        }
        else
        {
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Displays the goodbye message
    /// </summary>
    private static void ShowGoodbyeMessage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
    🐵 ====================== 🐵
         이용해 주셔서 감사합니다!
    🐵 ====================== 🐵
        ");
        Console.ResetColor();
        Console.WriteLine("원숭이 정보 시스템을 종료합니다.");
        Console.WriteLine("좋은 하루 보내세요! 🍌");
        Console.WriteLine();
    }
}
