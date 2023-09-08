using System.Collections.Generic;

namespace mitoSoft.Holidays
{
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

        public static IHolidays GetHolidays(string countryCode)
        {
            _countries.TryGetValue(countryCode, out var holidays);

            return holidays;
        }

        public static void RegisterHolidays(string countryCode, IHolidays holidays)
            => _countries[countryCode] = holidays;
    }
}