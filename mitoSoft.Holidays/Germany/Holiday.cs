using System;

namespace mitoSoft.Holidays.Germany
{
    public sealed class Holiday : Holiday<Bundeslaender>
    {
        public Bundeslaender Bundeslaender => this.AdministrativeDivisions;

        internal Holiday(string name, DateTime date, bool isFix, Bundeslaender bundeslaender)
            : base(name, date, date, isFix, bundeslaender)
        {
        }

        public override bool IsHoliday(Bundeslaender bundeslaender)
            => this.Bundeslaender.HasFlag(bundeslaender);
    }
}