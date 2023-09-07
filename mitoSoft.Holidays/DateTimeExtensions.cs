using System;

namespace mitoSoft.Holidays.Extensions
{
    public static class DateTimeExtensions
    {
        public static Holiday<T> GetHoliday<T>(this DateTime actualDate, Holidays<T> holidays)
            where T : struct, Enum
            => holidays.GetHoliday(actualDate);

        public static bool IsHoliday<T>(this DateTime actualDate, Holidays<T> holidays, T administrativeDivision)
            where T : struct, Enum
            => holidays.IsHoliday(actualDate, administrativeDivision);

        public static IHoliday GetHoliday(this DateTime actualDate, IHolidays holidays)
            => holidays.GetHoliday(actualDate);

        public static bool IsHoliday(this DateTime actualDate, IHolidays holidays, string administrativeDivision)
          => holidays.IsHoliday(actualDate, administrativeDivision);
    }
}