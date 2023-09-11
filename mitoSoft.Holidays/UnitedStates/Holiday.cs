using System;

namespace mitoSoft.Holidays.UnitedStates
{
    public sealed class Holiday : Holiday<States>
    {
        public States States => this.AdministrativeDivisions;

        internal Holiday(string name, DateTime originalDate, bool isFix, States states)
            : base(name, originalDate, GetActualDate(originalDate), isFix, states)
        {
        }

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