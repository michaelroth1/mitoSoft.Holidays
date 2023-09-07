using System;

namespace mitoSoft.Holidays.Extensions
{
    public static class UnitedStatesDateTimeExtensions
    {
        public static UnitedStates.Holiday GetUSHoliday(this DateTime actualDate)
        {
            var holiday = actualDate.GetHoliday(new UnitedStates.Holidays()) as UnitedStates.Holiday;

            return holiday;
        }

        public static bool IsUSHoliday(this DateTime actualDate, UnitedStates.States states = UnitedStates.States.Federal)
        {
            var holiday = actualDate.GetUSHoliday();

            var isHoliday = holiday?.IsHoliday(states) ?? false;

            return isHoliday;
        }
    }
}