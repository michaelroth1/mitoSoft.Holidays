using System;

namespace mitoSoft.Holidays.UnitedStates
{
    public class Holiday : HolidayBase<States>, IComparable<Holiday>
    {
        public Holiday(string name, DateTime originalDate, bool isFix, States states = States.National)
            : base(name, originalDate, GetActualDate(originalDate), isFix, states)
        {
        }

        public int CompareTo(Holiday other)
            => ActualDate.Date.CompareTo(other?.ActualDate.Date ?? DateTime.MaxValue);

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