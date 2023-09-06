using System;

namespace mitoSoft.Holidays.Germany
{
    public sealed class Holiday : Holiday<Bundeslaender>, IComparable<Holiday>, IEquatable<Holiday>
    {
        public Holiday(string name, DateTime date, bool isFix, Bundeslaender bundeslaender = Bundeslaender.National)
            : base(name, date, date, isFix, bundeslaender)
        {
        }

        public int CompareTo(Holiday other)
            => this.ActualDate.Date.CompareTo(other?.ActualDate.Date ?? DateTime.MaxValue);

        public bool Equals(Holiday other)
            => this.ActualDate.Date == other?.ActualDate.Date;
    }
}