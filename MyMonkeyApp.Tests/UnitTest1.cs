using MyMonkeyApp.Models;
using MyMonkeyApp.Services;

namespace MyMonkeyApp.Tests;

/// <summary>
/// Unit tests for MonkeyHelper service class.
/// </summary>
public class MonkeyHelperTests
{
    [Fact]
    public void GetMonkeys_ReturnsReadOnlyList()
    {
        // Act
        var monkeys = MonkeyHelper.GetMonkeys();

        // Assert
        Assert.IsAssignableFrom<IReadOnlyList<Monkey>>(monkeys);
        Assert.True(monkeys.Count > 0);
    }

    [Fact]
    public void GetMonkeys_ReturnsSortedList()
    {
        // Act
        var monkeys = MonkeyHelper.GetMonkeys();

        // Assert
        for (int i = 1; i < monkeys.Count; i++)
        {
            Assert.True(string.Compare(monkeys[i - 1].Name, monkeys[i].Name, StringComparison.Ordinal) <= 0);
        }
    }

    [Fact]
    public void GetMonkeyByName_WithValidName_ReturnsMonkey()
    {
        // Act
        var monkey = MonkeyHelper.GetMonkeyByName("Capuchin");

        // Assert
        Assert.NotNull(monkey);
        Assert.Equal("Capuchin", monkey.Name);
    }

    [Fact]
    public void GetMonkeyByName_CaseInsensitive_ReturnsMonkey()
    {
        // Act
        var monkey = MonkeyHelper.GetMonkeyByName("capuchin");

        // Assert
        Assert.NotNull(monkey);
        Assert.Equal("Capuchin", monkey.Name);
    }

    [Fact]
    public void GetMonkeyByName_WithInvalidName_ReturnsNull()
    {
        // Act
        var monkey = MonkeyHelper.GetMonkeyByName("NonExistentMonkey");

        // Assert
        Assert.Null(monkey);
    }

    [Fact]
    public void GetMonkeyByName_WithNullOrWhitespace_ThrowsArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => MonkeyHelper.GetMonkeyByName(""));
        Assert.Throws<ArgumentException>(() => MonkeyHelper.GetMonkeyByName("   "));
        Assert.Throws<ArgumentException>(() => MonkeyHelper.GetMonkeyByName(null!));
    }

    [Fact]
    public void GetRandomMonkey_ReturnsValidMonkey()
    {
        // Act
        var monkey = MonkeyHelper.GetRandomMonkey();

        // Assert
        Assert.NotNull(monkey);
        Assert.False(string.IsNullOrEmpty(monkey.Name));
        Assert.False(string.IsNullOrEmpty(monkey.Location));
        Assert.True(monkey.Population > 0);
    }

    [Fact]
    public void GetRandomMonkey_MultipleCallsReturnVariety()
    {
        // Act - Call multiple times to check for randomness
        var results = new HashSet<string>();
        for (int i = 0; i < 20; i++)
        {
            var monkey = MonkeyHelper.GetRandomMonkey();
            results.Add(monkey.Name);
        }

        // Assert - Should get at least 2 different monkeys in 20 calls
        Assert.True(results.Count >= 2);
    }

    [Fact]
    public void GetMonkeyCount_ReturnsPositiveNumber()
    {
        // Act
        var count = MonkeyHelper.GetMonkeyCount();

        // Assert
        Assert.True(count > 0);
        Assert.Equal(MonkeyHelper.GetMonkeys().Count, count);
    }
}