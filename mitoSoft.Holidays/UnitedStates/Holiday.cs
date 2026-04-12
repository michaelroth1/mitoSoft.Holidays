using System;

namespace mitoSoft.Holidays.UnitedStates
{
    /// <summary>
    /// Represents a holiday specific to the United States with state-level support.
    /// Implements weekend adjustment rules (Saturday holidays observed Friday, Sunday holidays observed Monday).
    /// </summary>
    public sealed class Holiday : Holiday<States>
    {
        /// <summary>
        /// Gets the US states where this holiday is observed.
        /// </summary>
        public States States => this.AdministrativeDivisions;

        internal Holiday(string name, DateTime originalDate, bool isFix, States states)
            : base(name, originalDate, GetActualDate(originalDate), isFix, states)
        {
        }

        /// <summary>
        /// Determines whether the holiday is observed in the specified state(s).
        /// </summary>
        /// <param name="states">The state(s) to check.</param>
        /// <returns>True if the holiday is observed in the specified state(s); otherwise, false.</returns>
        public override bool IsHoliday(States states)
            => states != States.None && this.States.HasFlag(states);

        private static DateTime GetActualDate(DateTime originalDate)
        {
            switch (originalDate.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    {
                        return originalDate.AddDays(-1);
                    }
                case DayOfWeek.Sunday:
                    {
                        return originalDate.AddDays(1);
                    }
                default:
                    {
                        return originalDate;
                    }
            }
        }
    }
}