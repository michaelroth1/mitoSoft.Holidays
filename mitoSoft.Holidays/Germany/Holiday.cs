using System;

namespace mitoSoft.Holidays.Germany
{
    /// <summary>
    /// Represents a holiday specific to Germany with Bundeslaender (federal states) support.
    /// </summary>
    public sealed class Holiday : Holiday<Bundeslaender>
    {
        /// <summary>
        /// Gets the German federal states (Bundeslaender) where this holiday is observed.
        /// </summary>
        public Bundeslaender Bundeslaender => this.AdministrativeDivisions;

        internal Holiday(string name, DateTime date, bool isFix, Bundeslaender bundeslaender)
            : base(name, date, date, isFix, bundeslaender)
        {
        }

        /// <summary>
        /// Determines whether the holiday is observed in the specified Bundesland.
        /// </summary>
        /// <param name="bundeslaender">The Bundesland to check.</param>
        /// <returns>True if the holiday is observed in the specified Bundesland; otherwise, false.</returns>
        public override bool IsHoliday(Bundeslaender bundeslaender)
            => bundeslaender != Bundeslaender.None && this.Bundeslaender.HasFlag(bundeslaender);
    }
}