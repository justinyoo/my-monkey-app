using System;
using System.Collections.Generic;
using System.Linq;
using MyMonkeyApp.Models;

namespace MyMonkeyApp.Helpers;

/// <summary>
/// Provides static helper methods for managing monkey data.
/// </summary>
public static class MonkeyHelper
{
    private static readonly List<Monkey> monkeys = new()
    {
        new Monkey { Name = "Baboon", Location = "Africa & Asia", Population = 10000, Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg", Latitude = -8.783195, Longitude = 34.508523 },
        new Monkey { Name = "Capuchin Monkey", Location = "Central & South America", Population = 23000, Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg", Latitude = 12.769013, Longitude = -85.602364 },
        new Monkey { Name = "Blue Monkey", Location = "Central and East Africa", Population = 12000, Details = "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/bluemonkey.jpg", Latitude = 1.957709, Longitude = 37.297204 },
        new Monkey { Name = "Squirrel Monkey", Location = "Central & South America", Population = 11000, Details = "The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/saimiri.jpg", Latitude = -8.783195, Longitude = -55.491477 },
        new Monkey { Name = "Golden Lion Tamarin", Location = "Brazil", Population = 19000, Details = "The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/tamarin.jpg", Latitude = -14.235004, Longitude = -51.92528 },
        new Monkey { Name = "Howler Monkey", Location = "South America", Population = 8000, Details = "Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/alouatta.jpg", Latitude = -8.783195, Longitude = -55.491477 },
        new Monkey { Name = "Japanese Macaque", Location = "Japan", Population = 1000, Details = "The Japanese macaque, is a terrestrial Old World monkey species native to Japan. They are also sometimes known as the snow monkey because they live in areas where snow covers the ground for months each", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/macasa.jpg", Latitude = 36.204824, Longitude = 138.252924 },
        new Monkey { Name = "Mandrill", Location = "Southern Cameroon, Gabon, and Congo", Population = 17000, Details = "The mandrill is a primate of the Old World monkey family, closely related to the baboons and even more closely to the drill. It is found in southern Cameroon, Gabon, Equatorial Guinea, and Congo.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/mandrill.jpg", Latitude = 7.369722, Longitude = 12.354722 },
        new Monkey { Name = "Proboscis Monkey", Location = "Borneo", Population = 15000, Details = "The proboscis monkey or long-nosed monkey, known as the bekantan in Malay, is a reddish-brown arboreal Old World monkey that is endemic to the south-east Asian island of Borneo.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/borneo.jpg", Latitude = 0.961883, Longitude = 114.55485 },
        new Monkey { Name = "Sebastian", Location = "Seattle", Population = 1, Details = "This little trouble maker lives in Seattle with James and loves traveling on adventures with James and tweeting @MotzMonkeys. He by far is an Android fanboy and is getting ready for the new Google Pixel 9!", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/sebastian.jpg", Latitude = 47.606209, Longitude = -122.332071 },
        new Monkey { Name = "Henry", Location = "Phoenix", Population = 1, Details = "An adorable Monkey who is traveling the world with Heather and live tweets his adventures @MotzMonkeys. His favorite platform is iOS by far and is excited for the new iPhone Xs!", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/henry.jpg", Latitude = 33.448377, Longitude = -112.074037 },
        new Monkey { Name = "Red-shanked douc", Location = "Vietnam", Population = 1300, Details = "The red-shanked douc is a species of Old World monkey, among the most colourful of all primates. The douc is an arboreal and diurnal monkey that eats and sleeps in the trees of the forest.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/douc.jpg", Latitude = 16.111648, Longitude = 108.262122 },
        new Monkey { Name = "Mooch", Location = "Seattle", Population = 1, Details = "An adorable Monkey who is traveling the world with Heather and live tweets his adventures @MotzMonkeys. Her favorite platform is iOS by far and is excited for the new iPhone 16!", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/Mooch.PNG", Latitude = 47.608013, Longitude = -122.335167 }
    };

    private static int randomMonkeyAccessCount = 0;
    private static readonly Random random = new();

    /// <summary>
    /// Gets the list of all monkeys.
    /// </summary>
    public static IReadOnlyList<Monkey> GetMonkeys() => monkeys;

    /// <summary>
    /// Gets a random monkey and tracks access count.
    /// </summary>
    public static Monkey GetRandomMonkey()
    {
        randomMonkeyAccessCount++;
        var index = random.Next(monkeys.Count);
        return monkeys[index];
    }

    /// <summary>
    /// Gets a monkey by its name.
    /// </summary>
    /// <param name="name">The name of the monkey to find.</param>
    /// <returns>The monkey with the specified name, or null if not found.</returns>
    public static Monkey? GetMonkeyByName(string name)
    {
        return monkeys.FirstOrDefault(m => string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets the access count for random monkey selection.
    /// </summary>
    public static int GetRandomMonkeyAccessCount() => randomMonkeyAccessCount;
}
