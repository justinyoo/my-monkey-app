using MyMonkeyApp.Models;
using MyMonkeyApp.Services;

namespace MyMonkeyApp.Services;

/// <summary>
/// Handles the console user interface and menu interactions
/// </summary>
public static class ConsoleUI
{
    /// <summary>
    /// Displays the main menu and handles user input
    /// </summary>
    public static void ShowMainMenu()
    {
        bool running = true;
        
        while (running)
        {
            Console.Clear();
            ShowHeader();
            ShowMenuOptions();
            
            var choice = GetUserChoice();
            
            switch (choice)
            {
                case "1":
                    ShowAllMonkeys();
                    break;
                case "2":
                    SearchMonkeyByName();
                    break;
                case "3":
                    ShowRandomMonkey();
                    break;
                case "4":
                    ShowMonkeyCount();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    /// <summary>
    /// Displays the application header
    /// </summary>
    private static void ShowHeader()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("🐵 =============================================");
        Console.WriteLine("    MY MONKEY APP - 원숭이 정보 시스템");
        Console.WriteLine("🐵 =============================================");
        Console.ResetColor();
        Console.WriteLine();
    }

    /// <summary>
    /// Displays the menu options
    /// </summary>
    private static void ShowMenuOptions()
    {
        Console.WriteLine("📋 메뉴를 선택하세요:");
        Console.WriteLine("1. 모든 원숭이 리스트 보기");
        Console.WriteLine("2. 원숭이 이름으로 검색");
        Console.WriteLine("3. 랜덤 원숭이 보기");
        Console.WriteLine("4. 원숭이 총 개수 보기");
        Console.WriteLine("5. 종료");
        Console.WriteLine();
    }

    /// <summary>
    /// Gets the user's menu choice
    /// </summary>
    /// <returns>The user's input as a string</returns>
    private static string GetUserChoice()
    {
        Console.Write("선택: ");
        return Console.ReadLine()?.Trim() ?? string.Empty;
    }

    /// <summary>
    /// Displays all monkeys in the collection
    /// </summary>
    private static void ShowAllMonkeys()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🐵 모든 원숭이 리스트");
        Console.WriteLine("===================");
        Console.ResetColor();
        
        try
        {
            var monkeys = MonkeyHelper.GetMonkeys();
            
            for (int i = 0; i < monkeys.Count; i++)
            {
                var monkey = monkeys[i];
                Console.WriteLine($"{i + 1}. {monkey}");
            }
            
            Console.WriteLine();
            Console.WriteLine("자세한 정보를 보려면 원숭이 이름으로 검색해보세요!");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"오류가 발생했습니다: {ex.Message}");
            Console.ResetColor();
        }
        
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    /// <summary>
    /// Handles searching for a monkey by name
    /// </summary>
    private static void SearchMonkeyByName()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("🔍 원숭이 이름으로 검색");
        Console.WriteLine("===================");
        Console.ResetColor();
        
        Console.Write("검색할 원숭이 이름을 입력하세요: ");
        string searchName = Console.ReadLine()?.Trim() ?? string.Empty;
        
        if (string.IsNullOrEmpty(searchName))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("검색할 이름을 입력해주세요.");
            Console.ResetColor();
        }
        else
        {
            try
            {
                var monkey = MonkeyHelper.GetMonkeyByName(searchName);
                
                if (monkey != null)
                {
                    DisplayMonkeyDetails(monkey);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"'{searchName}'와 일치하는 원숭이를 찾을 수 없습니다.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"검색 중 오류가 발생했습니다: {ex.Message}");
                Console.ResetColor();
            }
        }
        
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    /// <summary>
    /// Displays a random monkey from the collection
    /// </summary>
    private static void ShowRandomMonkey()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("🎲 랜덤 원숭이");
        Console.WriteLine("=============");
        Console.ResetColor();
        
        try
        {
            var monkey = MonkeyHelper.GetRandomMonkey();
            DisplayMonkeyDetails(monkey);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"랜덤 원숭이를 가져오는 중 오류가 발생했습니다: {ex.Message}");
            Console.ResetColor();
        }
        
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    /// <summary>
    /// Displays the total count of monkeys
    /// </summary>
    private static void ShowMonkeyCount()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("📊 원숭이 통계");
        Console.WriteLine("=============");
        Console.ResetColor();
        
        try
        {
            int count = MonkeyHelper.GetMonkeyCount();
            Console.WriteLine($"총 원숭이 종류: {count}개");
            
            var monkeys = MonkeyHelper.GetMonkeys();
            int totalPopulation = monkeys.Sum(m => m.Population);
            Console.WriteLine($"총 개체 수: {totalPopulation:N0}마리");
            
            Console.WriteLine();
            Console.WriteLine("지역별 분포:");
            var locationGroups = monkeys.GroupBy(m => m.Location);
            foreach (var group in locationGroups)
            {
                Console.WriteLine($"  - {group.Key}: {group.Count()}종");
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"통계를 가져오는 중 오류가 발생했습니다: {ex.Message}");
            Console.ResetColor();
        }
        
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    /// <summary>
    /// Displays detailed information about a specific monkey
    /// </summary>
    /// <param name="monkey">The monkey to display</param>
    private static void DisplayMonkeyDetails(Monkey monkey)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"🐵 {monkey.Name}");
        Console.WriteLine(new string('=', monkey.Name.Length + 3));
        Console.ResetColor();
        
        Console.WriteLine($"📍 서식지: {monkey.Location}");
        Console.WriteLine($"👥 개체 수: {monkey.Population:N0}마리");
        Console.WriteLine($"ℹ️  정보: {monkey.Details}");
        
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("ASCII 아트:");
        Console.WriteLine(monkey.AsciiArt);
        Console.ResetColor();
    }
}