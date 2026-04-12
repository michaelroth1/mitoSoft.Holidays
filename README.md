# mitoSoft.Holidays

A lightweight, extensible .NET library for determining holidays across different countries and their administrative divisions.

[![NuGet](https://img.shields.io/nuget/v/mitoSoft.Holidays.svg)](https://www.nuget.org/packages/mitoSoft.Holidays/)
[![License](https://img.shields.io/github/license/michaelroth1/mitoSoft.Holidays.svg)](LICENSE)

## Overview

mitoSoft.Holidays is a comprehensive holiday management library that provides:

- **Multi-Country Support**: Built-in support for German (Bundeslaender) and United States (States) holidays
- **Regional Awareness**: Holidays are tracked by administrative divisions (states, provinces, regions)
- **Fixed and Variable Dates**: Handles both fixed-date holidays (e.g., Christmas) and calculated holidays (e.g., Easter, Thanksgiving)
- **Localization**: Multi-language support for holiday names
- **Extensible Architecture**: Easy to add support for additional countries
- **DateTime Extensions**: Convenient extension methods for checking holidays

## Targets

- .NET Standard 2.0
- .NET 10.0

## Installation

Install via NuGet Package Manager:

```
Install-Package mitoSoft.Holidays
```

Or via .NET CLI:

```
dotnet add package mitoSoft.Holidays
```

## Key Concepts

### Administrative Divisions

Administrative divisions are geographical areas into which a country is divided. Different countries have different types of administrative divisions:

- **United States**: States (e.g., California, Texas, New York)
- **Germany**: Bundeslaender (e.g., Bayern, Berlin, Hamburg)
- **Canada**: Provinces and territories
- **France**: Departments

Holidays may be observed differently across these divisions. For example:
- In the US, Columbus Day is a federal holiday but not observed in all states
- In Germany, Epiphany is only observed in Baden-Wurttemberg, Bayern, and Sachsen-Anhalt

## Quick Start

### Using Country-Specific Holiday Classes

```csharp
using mitoSoft.Holidays.Germany;
using mitoSoft.Holidays.Extensions;

// Get all German holidays for a specific year
var germanHolidays = new Holidays();
var holidays2024 = germanHolidays.GetHolidays(2024);

// Check if a date is a holiday in a specific Bundesland
var date = new DateTime(2024, 1, 6); // Epiphany
bool isHolidayInBayern = germanHolidays.IsHoliday(date, Bundeslaender.Bayern); // true
bool isHolidayInBerlin = germanHolidays.IsHoliday(date, Bundeslaender.Berlin); // false

// Using extension methods
bool isHoliday = date.IsHoliday(germanHolidays, Bundeslaender.Bayern);
var holiday = date.GetHoliday(germanHolidays);
```

### Using the HolidaysHelper

```csharp
using mitoSoft.Holidays;

// Get holidays by country code
var germanHolidays = HolidaysHelper.GetHolidays("de");
var usHolidays = HolidaysHelper.GetHolidays("us");

var date = new DateTime(2024, 7, 4);
bool isUSHoliday = usHolidays.IsHoliday(date, "Federal");
```

### Working with United States Holidays

```csharp
using mitoSoft.Holidays.UnitedStates;
using mitoSoft.Holidays.Extensions;

var usHolidays = new Holidays();

// Check federal holidays
var independenceDay = new DateTime(2024, 7, 4);
bool isFederalHoliday = usHolidays.IsHoliday(independenceDay, States.Federal);

// Get all holidays for a specific date
var allHolidaysOnDate = usHolidays.GetHolidays(independenceDay);

// Check state-specific holidays
var date = new DateTime(2024, 10, 14); // Columbus Day / Indigenous Peoples' Day
bool isHolidayInCalifornia = usHolidays.IsHoliday(date, States.California);
```

### Getting Holiday Information

```csharp
using System.Globalization;

var germanHolidays = new mitoSoft.Holidays.Germany.Holidays();
var christmas = new DateTime(2024, 12, 25);

var holiday = germanHolidays.GetHoliday(christmas);

// Get localized name
string nameInGerman = holiday.GetDisplayName(new CultureInfo("de-DE"));
string nameInEnglish = holiday.GetDisplayName(new CultureInfo("en-US"));

// Get holiday properties
DateTime originalDate = holiday.OriginalDate;
DateTime observedDate = holiday.ObservedDate;
bool isFixed = holiday.IsFixedDate;

// Get administrative divisions where it's observed
var divisions = holiday.GetAdministrativeDivisions();
```

## Supported Holidays

### Germany (Bundeslaender)

**National Holidays:**
- New Year's Day (Neujahr)
- Good Friday (Karfreitag)
- Easter Sunday (Ostersonntag)
- Easter Monday (Ostermontag)
- Labor Day (Tag der Arbeit)
- Feast of the Ascension (Christi Himmelfahrt)
- Pentecost Sunday (Pfingstsonntag)
- Whit Monday (Pfingstmontag)
- German Unity Day (Tag der Deutschen Einheit)
- Christmas Eve (Heiligabend)
- Christmas Day (1. Weihnachtsfeiertag)
- Boxing Day (2. Weihnachtsfeiertag)

**Regional Holidays:**
- Epiphany (Heilige Drei Konige) - BW, BY, ST
- International Women's Day (Internationaler Frauentag) - BE
- Assumption of Mary (Maria Himmelfahrt) - SL
- Luther Reformation Day (Reformationstag) - BB, MV, SN, ST, TH, HH, HB, NI, SH
- All Saints' Day (Allerheiligen) - BW, BY, NW, RP, SL
- Feast of Corpus Christi (Fronleichnam) - BW, BY, HE, NW, RP, SL

### United States (States)

**Federal Holidays:**
- New Year's Day
- Martin Luther King Jr. Day (3rd Monday in January)
- George Washington's Birthday / Presidents' Day (3rd Monday in February)
- Memorial Day (Last Monday in May)
- Juneteenth National Independence Day
- Independence Day
- Labor Day (1st Monday in September)
- Columbus Day / Indigenous Peoples' Day (2nd Monday in October)
- Veterans Day
- Thanksgiving Day (4th Thursday in November)
- Christmas Day

## Extending the Library

### Adding a New Country

To add support for a new country:

1. **Create an enum for administrative divisions:**

```csharp
using System;

namespace mitoSoft.Holidays.YourCountry
{
    [Flags]
    public enum Regions : uint
    {
        None = 0,
        Region1 = 1 << 0,
        Region2 = 1 << 1,
        Region3 = 1 << 2,
        // Add more regions...

        National = Region1 | Region2 | Region3
    }
}
```

2. **Create a Holiday class:**

```csharp
namespace mitoSoft.Holidays.YourCountry
{
    public sealed class Holiday : Holiday<Regions>
    {
        public Holiday(string name, DateTime date, bool isFixedDate, Regions regions)
            : base(name, date, date, isFixedDate, regions)
        {
        }

        public override bool IsHoliday(Regions region)
            => this.AdministrativeDivisions.HasFlag(region);
    }
}
```

3. **Create a Holidays class:**

```csharp
using System;
using System.Collections.Generic;

namespace mitoSoft.Holidays.YourCountry
{
    public sealed class Holidays : Holidays<Regions>
    {
        public Holidays() : base("Your Country Name")
        {
        }

        public override IEnumerable<Holiday<Regions>> GetHolidays(int year)
        {
            yield return new Holiday("NewYear", new DateTime(year, 1, 1), true, Regions.National);
            // Add more holidays...
        }
    }
}
```

4. **Register with HolidaysHelper:**

```csharp
HolidaysHelper.RegisterHolidays("yc", new YourCountry.Holidays());
```

### Easter Calculation

The library includes a built-in `EasterSunday` calculator that uses the Oudin (1940) algorithm:

```csharp
var easterSunday = EasterSunday.Get(2024); // April 31, 2024
var goodFriday = easterSunday.AddDays(-2);
var easterMonday = easterSunday.AddDays(1);
var ascension = easterSunday.AddDays(39);
var pentecost = easterSunday.AddDays(49);
```

## API Reference

### Core Interfaces

- `IHoliday` - Represents a single holiday
- `IHolidays` - Represents a collection of holidays for a country

### Core Classes

- `Holiday<T>` - Base class for holiday implementations
- `Holidays<T>` - Base class for country holiday collections
- `HolidaysHelper` - Static helper for managing multiple countries

### Extension Methods

- `GetHoliday(DateTime, IHolidays)` - Get holiday on a specific date
- `IsHoliday(DateTime, IHolidays, string)` - Check if date is a holiday

## Localization

The library supports multiple languages through resource files. Holiday names can be localized:

```csharp
var holiday = germanHolidays.GetHoliday(new DateTime(2024, 12, 25));

// Get German name
string german = holiday.GetDisplayName(new CultureInfo("de-DE")); // "1. Weihnachtsfeiertag"

// Get English name
string english = holiday.GetDisplayName(new CultureInfo("en-US")); // "Christmas Day"
```

## Examples

For more comprehensive examples, see the test classes in the [test project](mitoSoft.Holidays.Tests).

### Check Multiple Years

```csharp
var germanHolidays = new mitoSoft.Holidays.Germany.Holidays();

for (int year = 2020; year <= 2025; year++)
{
    var easterSunday = EasterSunday.Get(year);
    Console.WriteLine($"Easter {year}: {easterSunday:yyyy-MM-dd}");
}
```

### Find All Holidays in a State

```csharp
var usHolidays = new mitoSoft.Holidays.UnitedStates.Holidays();
var californiaHolidays = usHolidays.GetHolidays(2024)
    .Where(h => h.IsHoliday(States.California))
    .OrderBy(h => h.ObservedDate);

foreach (var holiday in californiaHolidays)
{
    Console.WriteLine($"{holiday.ObservedDate:yyyy-MM-dd} - {holiday.GetDisplayName()}");
}
```

### Weekend Adjustment (Custom Implementation)

```csharp
// The library tracks both OriginalDate and ObservedDate
// You can implement custom weekend adjustment logic as needed

var holiday = usHolidays.GetHoliday(new DateTime(2024, 7, 4));
DateTime originalDate = holiday.OriginalDate;    // 2024-07-04
DateTime observedDate = holiday.ObservedDate;    // 2024-07-04
```

## Contributing

Contributions are welcome! Please feel free to submit pull requests or open issues for:

- Adding new countries
- Fixing holiday definitions
- Adding translations
- Improving documentation

## License

This project is licensed under the terms specified in the [LICENSE](LICENSE) file.

## Links

- [GitHub Repository](https://github.com/michaelroth1/mitoSoft.Holidays)
- [NuGet Package](https://www.nuget.org/packages/mitoSoft.Holidays/)

## Acknowledgments

- Easter calculation based on the algorithm of Oudin (1940) as quoted in "Explanatory Supplement to the Astronomical Almanac", P. Kenneth Seidelmann
- German holidays reference: https://www.feiertage.net/bundeslaender.php
- US federal holidays reference: https://en.wikipedia.org/wiki/Federal_holidays_in_the_United_States