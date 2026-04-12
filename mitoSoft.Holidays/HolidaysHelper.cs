using System.Collections.Generic;

namespace mitoSoft.Holidays
{
    /// <summary>
    /// Provides helper methods for retrieving and managing holiday collections by country code.
    /// </summary>
    public static class HolidaysHelper
    {
        private static readonly Dictionary<string, IHolidays> _countries;

        static HolidaysHelper()
        {
            _countries = new Dictionary<string, IHolidays>()
            {
                { "de", new Germany.Holidays() },
                { "us", new UnitedStates.Holidays() },
            };
        }

        /// <summary>
        /// Gets the holiday collection for the specified country code.
        /// </summary>
        /// <param name="countryCode">The ISO 3166-1 alpha-2 country code (e.g., "de" for Germany, "us" for United States).</param>
        /// <returns>The holiday collection for the specified country, or null if the country code is not registered.</returns>
        public static IHolidays GetHolidays(string countryCode)
        {
            _countries.TryGetValue(countryCode, out var holidays);

            return holidays;
        }

        /// <summary>
        /// Registers or updates the holiday collection for the specified country code.
        /// </summary>
        /// <param name="countryCode">The ISO 3166-1 alpha-2 country code (e.g., "de" for Germany, "us" for United States).</param>
        /// <param name="holidays">The holiday collection to register for the country.</param>
        public static void RegisterHolidays(string countryCode, IHolidays holidays)
            => _countries[countryCode] = holidays;
    }
}