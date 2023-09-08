using System;
using mitoSoft.Holidays.UnitedStates;

namespace mitoSoft.Holidays.Extensions
{
    public static class UnitedStatesDateTimeExtensions
    {
        public static Holiday GetUSHoliday(this DateTime actualDate)
        {
            var holiday = actualDate.GetHoliday(new UnitedStates.Holidays()) as Holiday;

            return holiday;
        }

        public static bool IsUSHoliday(this DateTime actualDate, States states = States.Federal)
        {
            var holiday = actualDate.GetUSHoliday();

            var isHoliday = holiday?.IsHoliday(states) ?? false;

            return isHoliday;
        }
    }
}