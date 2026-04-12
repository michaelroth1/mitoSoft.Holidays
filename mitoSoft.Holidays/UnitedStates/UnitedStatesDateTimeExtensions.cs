using System;
using mitoSoft.Holidays.UnitedStates;

namespace mitoSoft.Holidays.Extensions
{
    /// <summary>
    /// Provides extension methods for DateTime to work with United States holidays.
    /// </summary>
    public static class UnitedStatesDateTimeExtensions
    {
        /// <summary>
        /// Gets the US holiday that falls on the specified date.
        /// </summary>
        /// <param name="actualDate">The date to check.</param>
        /// <returns>The US holiday that falls on the specified date, or null if no holiday exists on that date.</returns>
        public static Holiday GetUSHoliday(this DateTime actualDate)
        {
            var holiday = actualDate.GetHoliday(new UnitedStates.Holidays()) as Holiday;

            return holiday;
        }

        /// <summary>
        /// Determines whether the specified date is a US holiday in the given state(s).
        /// </summary>
        /// <param name="actualDate">The date to check.</param>
        /// <param name="states">The state(s) to check. Defaults to Federal (all states).</param>
        /// <returns>True if the specified date is a US holiday in the given state(s); otherwise, false.</returns>
        public static bool IsUSHoliday(this DateTime actualDate, States states = States.Federal)
        {
            var holiday = actualDate.GetUSHoliday();

            var isHoliday = holiday?.IsHoliday(states) ?? false;

            return isHoliday;
        }
    }
}