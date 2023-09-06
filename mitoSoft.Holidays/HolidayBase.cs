using System;

namespace mitoSoft.Holidays
{
    public abstract class HolidayBase<T> : IComparable<HolidayBase<T>>
        where T : struct, Enum
    {
        /// <summary />
        public string Name { get; }

        /// <summary>
        /// Determines when the holiday's original date.
        /// </summary>
        public DateTime OriginalDate { get; }

        /// <summary>
        /// The date that the holiday actually takes place
        /// </summary>
        public DateTime ActualDate { get; }

        /// <summary>
        /// Determines if the holiday is defined by a date in a year
        /// </summary>
        public bool IsFixedDate { get; }

        /// <summary />
        public T Provinces { get; }

        protected HolidayBase(string name
            , DateTime originalDate
            , DateTime date
            , bool isFixedDate
            , T provinces)
        {
            this.Name = name;
            this.Provinces = provinces;
            this.OriginalDate = originalDate;
            this.ActualDate = date;
            this.IsFixedDate = isFixedDate;
        }

        public int CompareTo(HolidayBase<T> other)
           => this.ActualDate.Date.CompareTo(other?.ActualDate.Date ?? DateTime.MaxValue);
    }
}