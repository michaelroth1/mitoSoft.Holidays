using System;

namespace mitoSoft.Holidays.Germany
{
    public class Holiday : HolidayBase<Bundeslaender>, IComparable<Holiday>
    {
        public Holiday(string name, DateTime date, bool isFix, Bundeslaender bundeslaender = Bundeslaender.National)
            : base(name, date, date, isFix, bundeslaender)
        {
        }

        public int CompareTo(Holiday other)
            => ActualDate.Date.CompareTo(other?.ActualDate.Date ?? DateTime.MaxValue);
    }
}