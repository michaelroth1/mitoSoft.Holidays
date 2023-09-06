using System;
using System.Globalization;
using System.Resources;

namespace mitoSoft.Holidays
{
    public abstract class HolidayBase<T> : IComparable<HolidayBase<T>>
        where T : struct, Enum
    {
        private readonly ResourceManager _resourceManager;

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
            , DateTime actualDate
            , bool isFixedDate
            , T provinces
            , ResourceManager resourceManager = null)
        {
            this.Name = name;
            this.OriginalDate = originalDate;
            this.ActualDate = actualDate;
            this.IsFixedDate = isFixedDate;
            this.Provinces = provinces;
            _resourceManager = resourceManager ?? Resources.ResourceManager;
        }

        public int CompareTo(HolidayBase<T> other)
           => this.ActualDate.Date.CompareTo(other?.ActualDate.Date ?? DateTime.MaxValue);

        public virtual string GetDisplayName(CultureInfo cultureInfo = null)
        {
            var result = cultureInfo != null
                ? _resourceManager.GetString(this.Name, cultureInfo)
                : _resourceManager.GetString(this.Name);

            return result;
        }
    }
}