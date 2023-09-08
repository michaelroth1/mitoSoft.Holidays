using System;
using mitoSoft.Holidays.Germany;

namespace mitoSoft.Holidays.Extensions
{
    public static class GermanyDateTimeExtensions
    {
        public static Holiday GetGermanHoliday(this DateTime actualDate)
        {
            var holiday = actualDate.GetHoliday(new Germany.Holidays()) as Holiday;

            return holiday;
        }

        public static bool IsGermanHoliday(this DateTime actualDate, Bundeslaender bundeslaender = Bundeslaender.National)
        {
            var holiday = actualDate.GetGermanHoliday();

            var isHoliday = holiday?.IsHoliday(bundeslaender) ?? false;

            return isHoliday;
        }
    }
}