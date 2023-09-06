using System;

namespace mitoSoft.Holidays.UnitedStates
{
    public static class DateTimeExtensions
    {
        public static UnitedStatesHoliday GetUSHoliday(this DateTime actualDate)
        {
            var holiday = actualDate.GetHoliday(new UnitedStatesHolidays()) as UnitedStatesHoliday;

            return holiday;
        }

        public static bool IsUSHoliday(this DateTime actualDate, UnitedStatesStates states = UnitedStatesStates.National)
        {
            var holiday = actualDate.GetUSHoliday();

            var isHoliday = holiday.IsHoliday(states);

            return isHoliday;
        }
    }
}