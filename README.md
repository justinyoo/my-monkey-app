# My Monkey App 🐒

A fun and interactive C# console application for exploring monkey species from around the world!

## Features

- 🐵 **Browse All Species**: View a complete list of monkey species with their locations and populations
- 🔍 **Smart Search**: Find specific monkeys by name (case-insensitive)
- 🎲 **Random Discovery**: Get surprised with a randomly selected monkey species
- 🎨 **ASCII Art**: Enjoy colorful output with monkey-themed ASCII art
- 📊 **Rich Data**: Information on 12 different monkey species from around the globe

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or later

### Installation & Running

1. Clone the repository:
```bash
git clone https://github.com/justinyoo/my-monkey-app.git
cd my-monkey-app
```

2. Navigate to the project directory:
```bash
cd MyMonkeyApp
```

3. Build and run the application:
```bash
dotnet build
dotnet run
```

## Usage

When you run the application, you'll see a welcome banner and main menu:

```
   __,._
  (o,o)  🐒 Monkey Explorer 🐒
  (   )
   "-"    Welcome to the Monkey Species Database!

🌟 Discover amazing monkey species from around the world!
📊 Currently featuring 12 different species

================================================
🐒 MONKEY EXPLORER - MAIN MENU
================================================
1️⃣  List All Monkeys
2️⃣  Search by Name
3️⃣  Random Monkey
0️⃣  Exit

👉 Please select an option:
```

### Menu Options

#### 1. List All Monkeys
Displays all monkey species in an organized table format, sorted alphabetically:

```
🐵 ALL MONKEY SPECIES
================================================
Species Name              | Location             | Population
------------------------- | -------------------- | ---------------
Baboon                    | Africa & Arabia      | Population: 300,000
Capuchin                  | Central & South America | Population: 250,000
Gelada                    | Ethiopia             | Population: 200,000
...
✅ Total: 12 species found
```

#### 2. Search by Name
Search for a specific monkey species by name (case-insensitive):

```
🔍 SEARCH MONKEY BY NAME
================================================
Enter monkey name to search: capuchin

✅ Monkey Found!

    🐵
   /|\
    ^

Name: Capuchin
Location: Central & South America
Population: 250,000
```

#### 3. Random Monkey
Get a randomly selected monkey species with fun ASCII art:

```
🎲 RANDOM MONKEY SELECTION
================================================
🎉 Here's your randomly selected monkey:

      .-"-. 
     /      \ 
    |  o    o |
    |    <>   |
    |   ___   |
     \       /
      '-----'

🐒 Name: Gelada
🌍 Location: Ethiopia
👥 Population: 200,000
```

## Project Structure

```
MyMonkeyApp/
├── Program.cs              # Main entry point and menu loop
├── Models/
│   └── Monkey.cs          # Monkey species data model
├── Services/
│   └── MonkeyHelper.cs    # Static helper for data operations
└── Art/
    └── MonkeyArt.cs       # ASCII art constants
```

## Monkey Species Database

The application includes data for 12 fascinating monkey species:

- **Capuchin** (Central & South America) - 250,000
- **Howler Monkey** (South America) - 150,000  
- **Spider Monkey** (Central America) - 75,000
- **Proboscis Monkey** (Borneo) - 7,000
- **Golden Snub-Nosed Monkey** (China) - 15,000
- **Mandrill** (Equatorial Africa) - 20,000
- **Japanese Macaque** (Japan) - 50,000
- **Gelada** (Ethiopia) - 200,000
- **Vervet Monkey** (East Africa) - 500,000
- **Rhesus Macaque** (Asia) - 1,000,000
- **Baboon** (Africa & Arabia) - 300,000
- **Gibbon** (Southeast Asia) - 30,000

## Technical Details

- **Framework**: .NET 8.0
- **Language**: C# 12 with nullable reference types enabled
- **Architecture**: Console application with separation of concerns
- **Error Handling**: Comprehensive input validation and exception handling
- **Search**: Case-insensitive string matching using `StringComparison.OrdinalIgnoreCase`
- **Random Selection**: Uses `Random.Shared` for thread-safe random number generation

## Contributing

Feel free to contribute by:
- Adding more monkey species to the database
- Improving the ASCII art
- Adding new features like filtering by population or location
- Enhancing the user interface

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

*Happy monkey exploring! 🐒🌍*