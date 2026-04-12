using System;
using mitoSoft.Holidays.Germany;

namespace mitoSoft.Holidays.Extensions
{
    /// <summary>
    /// Provides extension methods for DateTime to work with German holidays.
    /// </summary>
    public static class GermanyDateTimeExtensions
    {
        /// <summary>
        /// Gets the German holiday that falls on the specified date.
        /// </summary>
        /// <param name="actualDate">The date to check.</param>
        /// <returns>The German holiday that falls on the specified date, or null if no holiday exists on that date.</returns>
        public static Holiday GetGermanHoliday(this DateTime actualDate)
        {
            var holiday = actualDate.GetHoliday(new Germany.Holidays()) as Holiday;

            return holiday;
        }

        /// <summary>
        /// Determines whether the specified date is a German holiday in the given Bundesland.
        /// </summary>
        /// <param name="actualDate">The date to check.</param>
        /// <param name="bundeslaender">The Bundesland to check. Defaults to National (all Bundeslaender).</param>
        /// <returns>True if the specified date is a German holiday in the given Bundesland; otherwise, false.</returns>
        public static bool IsGermanHoliday(this DateTime actualDate, Bundeslaender bundeslaender = Bundeslaender.National)
        {
            var holiday = actualDate.GetGermanHoliday();

            var isHoliday = holiday?.IsHoliday(bundeslaender) ?? false;

            return isHoliday;
        }
    }
}