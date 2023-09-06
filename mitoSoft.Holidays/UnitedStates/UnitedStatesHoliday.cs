using System;

namespace mitoSoft.Holidays.UnitedStates
{
    public class UnitedStatesHoliday : HolidayBase<UnitedStatesStates>, IComparable<UnitedStatesHoliday>
    {
        public UnitedStatesHoliday(string name, DateTime originalDate, bool isFix, UnitedStatesStates states = UnitedStatesStates.National)
            : base(name, originalDate, GetActualDate(originalDate), isFix, states)
        {
        }

        public int CompareTo(UnitedStatesHoliday other)
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