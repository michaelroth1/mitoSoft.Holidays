using System;

namespace mitoSoft.Holidays.Germany
{
    public static class DateTimeExtensions
    {
        public static Holiday GetGermanHoliday(this DateTime actualDate)
        {
            var holiday = actualDate.GetHoliday(new Holidays()) as Holiday;

            return holiday;
        }

        public static bool IsGermanHoliday(this DateTime actualDate, Bundeslaender bundeslaender = Bundeslaender.National)
        {
            var holiday = actualDate.GetGermanHoliday();

            var isHoliday = holiday.IsHoliday(bundeslaender);

            return isHoliday;
        }
    }
}