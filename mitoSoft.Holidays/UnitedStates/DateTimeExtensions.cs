using System;

namespace mitoSoft.Holidays.UnitedStates
{
    public static class DateTimeExtensions
    {
        public static Holiday GetUSHoliday(this DateTime actualDate)
        {
            var holiday = actualDate.GetHoliday(new Holidays()) as Holiday;

            return holiday;
        }

        public static bool IsUSHoliday(this DateTime actualDate, States states = States.National)
        {
            var holiday = actualDate.GetUSHoliday();

            var isHoliday = holiday.IsHoliday(states);

            return isHoliday;
        }
    }
}