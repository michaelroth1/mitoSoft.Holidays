using System;

namespace mitoSoft.Holidays.Extensions
{
    /// <summary>
    /// Provides extension methods for DateTime to work with holidays.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Gets the holiday that falls on the specified date.
        /// </summary>
        /// <typeparam name="T">An enum type representing the administrative divisions.</typeparam>
        /// <param name="actualDate">The date to check.</param>
        /// <param name="holidays">The holiday collection to search.</param>
        /// <returns>The holiday that falls on the specified date, or null if no holiday exists on that date.</returns>
        public static Holiday<T> GetHoliday<T>(this DateTime actualDate, Holidays<T> holidays)
            where T : struct, Enum
            => holidays.GetHoliday(actualDate);

        /// <summary>
        /// Determines whether the specified date is a holiday in the given administrative division.
        /// Administrative divisions are geographical areas into which a country is divided, such as states (US), provinces (Canada),
        /// Bundesländer (Germany), departments (France), or other regional subdivisions.
        /// </summary>
        /// <typeparam name="T">An enum type representing the administrative divisions.</typeparam>
        /// <param name="actualDate">The date to check.</param>
        /// <param name="holidays">The holiday collection to search.</param>
        /// <param name="administrativeDivision">The administrative division to check.</param>
        /// <returns>True if the specified date is a holiday in the given administrative division; otherwise, false.</returns>
        public static bool IsHoliday<T>(this DateTime actualDate, Holidays<T> holidays, T administrativeDivision)
            where T : struct, Enum
            => holidays.IsHoliday(actualDate, administrativeDivision);

        /// <summary>
        /// Gets the holiday that falls on the specified date.
        /// </summary>
        /// <param name="actualDate">The date to check.</param>
        /// <param name="holidays">The holiday collection to search.</param>
        /// <returns>The holiday that falls on the specified date, or null if no holiday exists on that date.</returns>
        public static IHoliday GetHoliday(this DateTime actualDate, IHolidays holidays)
            => holidays.GetHoliday(actualDate);

        /// <summary>
        /// Determines whether the specified date is a holiday in the given administrative division.
        /// Administrative divisions are geographical areas into which a country is divided, such as states (US), provinces (Canada),
        /// Bundesländer (Germany), departments (France), or other regional subdivisions.
        /// </summary>
        /// <param name="actualDate">The date to check.</param>
        /// <param name="holidays">The holiday collection to search.</param>
        /// <param name="administrativeDivision">The name of the administrative division (e.g., "California", "Bayern").</param>
        /// <returns>True if the specified date is a holiday in the given administrative division; otherwise, false.</returns>
        public static bool IsHoliday(this DateTime actualDate, IHolidays holidays, string administrativeDivision)
          => holidays.IsHoliday(actualDate, administrativeDivision);
    }
}