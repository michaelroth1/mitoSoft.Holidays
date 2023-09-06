using System;

namespace mitoSoft.Holidays.Germany
{
    public static class DateTimeExtensions
    {
        public static GermanHoliday GetGermanHoliday(this DateTime actualDate)
        {
            var holiday = actualDate.GetHoliday(new GermanHolidays()) as GermanHoliday;

            return holiday;
        }

        public static bool IsGermanHoliday(this DateTime actualDate, GermanBundeslaender bundeslaender = GermanBundeslaender.National)
        {
            var holiday = actualDate.GetGermanHoliday();

            var isHoliday = holiday.IsHoliday(bundeslaender);

            return isHoliday;
        }
    }
}