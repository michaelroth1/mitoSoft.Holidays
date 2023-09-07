using System;

namespace mitoSoft.Holidays.Extensions
{
    public static class GermanyDateTimeExtensions
    {
        public static Germany.Holiday GetGermanHoliday(this DateTime actualDate)
        {
            var holiday = actualDate.GetHoliday(new Germany.Holidays()) as Germany.Holiday;

            return holiday;
        }

        public static bool IsGermanHoliday(this DateTime actualDate, Germany.Bundeslaender bundeslaender = Germany.Bundeslaender.National)
        {
            var holiday = actualDate.GetGermanHoliday();

            var isHoliday = holiday?.IsHoliday(bundeslaender) ?? false;

            return isHoliday;
        }
    }
}