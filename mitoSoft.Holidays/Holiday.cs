using System;
using System.Globalization;
using System.Resources;

namespace mitoSoft.Holidays
{
    public class Holiday<T> : IComparable<Holiday<T>>, IEquatable<Holiday<T>>
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

        public Holiday(string name
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

        public virtual int CompareTo(Holiday<T> other)
           => this.ActualDate.Date.CompareTo(other?.ActualDate.Date ?? DateTime.MaxValue);

        public virtual bool Equals(Holiday<T> other)
            => this.ActualDate.Date == other?.ActualDate.Date;

        public virtual string GetDisplayName(CultureInfo cultureInfo = null)
        {
            var result = cultureInfo != null
                ? _resourceManager.GetString(this.Name, cultureInfo)
                : _resourceManager.GetString(this.Name);

            return result;
        }
    }
}