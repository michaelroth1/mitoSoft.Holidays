using System;

namespace mitoSoft.Holidays.UnitedStates
{
    public sealed class Holiday : Holiday<States>, IComparable<Holiday>, IEquatable<Holiday>
    {
        public Holiday(string name, DateTime originalDate, bool isFix, States states = States.National)
            : base(name, originalDate, GetActualDate(originalDate), isFix, states)
        {
        }

        public int CompareTo(Holiday other)
            => this.ActualDate.Date.CompareTo(other?.ActualDate.Date ?? DateTime.MaxValue);

        public bool Equals(Holiday other)
            => this.ActualDate.Date == other?.ActualDate.Date;

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