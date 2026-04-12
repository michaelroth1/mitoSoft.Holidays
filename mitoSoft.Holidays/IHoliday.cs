using System;
using System.Collections.Generic;
using System.Globalization;

namespace mitoSoft.Holidays
{
    /// <summary>
    /// Represents a holiday with information about its dates, name, and the administrative divisions where it is observed.
    /// </summary>
    public interface IHoliday
    {
        /// <summary>
        /// Gets the internal name of the holiday.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the original date of the holiday (the date it falls on according to the calendar).
        /// </summary>
        DateTime OriginalDate { get; }

        /// <summary>
        /// Gets the observed date of the holiday (the actual date when the holiday is celebrated, which may differ from the original date due to weekend shifts or other rules).
        /// </summary>
        DateTime ObservedDate { get; }

        /// <summary>
        /// Gets a value indicating whether the holiday is defined by a fixed date in a year (e.g., Christmas on December 25) or a variable date (e.g., Easter).
        /// </summary>
        bool IsFixedDate { get; }

        /// <summary>
        /// Gets the localized display name of the holiday based on the specified culture.
        /// </summary>
        /// <param name="cultureInfo">The culture to use for localization. If null, the current culture is used.</param>
        /// <returns>The localized name of the holiday.</returns>
        string GetDisplayName(CultureInfo cultureInfo = null);

        /// <summary>
        /// Determines whether the holiday is observed in the specified administrative division.
        /// Administrative divisions are geographical areas into which a country is divided, such as states (US), provinces (Canada), 
        /// Bundesländer (Germany), departments (France), or other regional subdivisions.
        /// </summary>
        /// <param name="administrativeDivision">The name of the administrative division (e.g., "California", "Bayern").</param>
        /// <returns>True if the holiday is observed in the specified administrative division; otherwise, false.</returns>
        bool IsHoliday(string administrativeDivision);

        /// <summary>
        /// Gets the names of all administrative divisions where this holiday is observed.
        /// Administrative divisions are geographical areas into which a country is divided, such as states (US), provinces (Canada),
        /// Bundesländer (Germany), departments (France), or other regional subdivisions.
        /// </summary>
        /// <returns>An enumerable collection of administrative division names.</returns>
        IEnumerable<string> GetAdministrativeDivisions();
    }
}