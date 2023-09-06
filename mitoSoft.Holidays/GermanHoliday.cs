using System;

namespace mitoSoft.Holidays.Models
{
    public class GermanHoliday : HolidayBase<GermanBundeslaender>, IComparable<GermanHoliday>
    {
        public GermanHoliday(string name, DateTime date, bool isFix, GermanBundeslaender bundeslaender = GermanBundeslaender.National)
            : base(name, date, date, isFix, bundeslaender)
        {
        }

        public int CompareTo(GermanHoliday other)
            => this.ActualDate.Date.CompareTo(other?.ActualDate.Date ?? DateTime.MaxValue);
    }
}