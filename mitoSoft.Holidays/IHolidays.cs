using System;
using System.Collections.Generic;

namespace mitoSoft.Holidays
{
    /// <summary>
    /// Represents a collection of holidays for a specific country.
    /// </summary>
    public interface IHolidays
    {
        /// <summary>
        /// Gets the name of the country for which this collection contains holidays.
        /// </summary>
        string Country { get; }

        /// <summary>
        /// Gets all holidays for the specified year.
        /// </summary>
        /// <param name="year">The year for which to retrieve holidays.</param>
        /// <returns>An enumerable collection of holidays.</returns>
        IEnumerable<IHoliday> GetHolidays(int year);

        /// <summary>
        /// Gets the first holiday that falls on the specified date.
        /// </summary>
        /// <param name="actualDate">The date to check.</param>
        /// <returns>The holiday that falls on the specified date, or null if no holiday exists on that date.</returns>
        IHoliday GetHoliday(DateTime actualDate);

        /// <summary>
        /// Gets all holidays that fall on the specified date.
        /// </summary>
        /// <param name="actualDate">The date to check.</param>
        /// <returns>An enumerable collection of holidays that fall on the specified date.</returns>
        IEnumerable<IHoliday> GetHolidays(DateTime actualDate);

        /// <summary>
        /// Determines whether the specified date is a holiday in the given administrative division.
        /// Administrative divisions are geographical areas into which a country is divided, such as states (US), provinces (Canada),
        /// Bundesländer (Germany), departments (France), or other regional subdivisions.
        /// </summary>
        /// <param name="actualDate">The date to check.</param>
        /// <param name="administrativeDivision">The name of the administrative division (e.g., "California", "Bayern").</param>
        /// <returns>True if the specified date is a holiday in the given administrative division; otherwise, false.</returns>
        bool IsHoliday(DateTime actualDate, string administrativeDivision);

        /// <summary>
        /// Gets the names of all administrative divisions for this country.
        /// Administrative divisions are geographical areas into which a country is divided, such as states (US), provinces (Canada),
        /// Bundesländer (Germany), departments (France), or other regional subdivisions.
        /// </summary>
        /// <returns>An enumerable collection of administrative division names.</returns>
        IEnumerable<string> GetAdministrativeDivisions();
    }
}