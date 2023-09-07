using System;
using System.Globalization;
using System.Resources;

namespace mitoSoft.Holidays
{
    public abstract class Holiday<T> : IHoliday, IComparable<Holiday<T>>, IEquatable<Holiday<T>>
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

        /// <summary>
        /// Administrative divisions (also administrative units, administrative regions, subnational entities,
        /// or a constituent states, as well as many similar generic terms) are geographical areas into which
        /// a particular independent Sovereign state is divided.
        /// </summary>
        public T AdministrativeDivisions { get; }

        protected Holiday(string name
            , DateTime originalDate
            , DateTime actualDate
            , bool isFixedDate
            , T administrativeDivisions
            , ResourceManager resourceManager = null)
        {
            this.Name = name;
            this.OriginalDate = originalDate;
            this.ActualDate = actualDate;
            this.IsFixedDate = isFixedDate;
            this.AdministrativeDivisions = administrativeDivisions;
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

            if (string.IsNullOrEmpty(result))
            {
                result = this.Name;
            }

            return result;
        }

        public abstract bool IsHoliday(T administrativeDivision);

        bool IHoliday.IsHoliday(string administrativeDivision)
        {
            if (Enum.TryParse<T>(administrativeDivision, out var enumValue))
            {
                var isHoliday = this.IsHoliday(enumValue);

                return isHoliday;
            }
            else
            {
                return false;
            }
        }
    }
}