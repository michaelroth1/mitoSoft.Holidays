using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Resources;

namespace mitoSoft.Holidays
{
    /// <summary>
    /// Represents an abstract base class for holidays with generic administrative division support.
    /// </summary>
    /// <typeparam name="T">An enum type representing the administrative divisions (e.g., states, provinces, regions) where the holiday may be observed.</typeparam>
    [DebuggerDisplay("{Name}")]
    public abstract class Holiday<T> : IHoliday, IComparable<Holiday<T>>, IEquatable<Holiday<T>>
        where T : struct, Enum
    {
        private readonly ResourceManager _resourceManager;

        /// <summary>
        /// Gets the internal name of the holiday.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the original date of the holiday (the date it falls on according to the calendar).
        /// </summary>
        public DateTime OriginalDate { get; }

        /// <summary>
        /// Gets the observed date of the holiday (the actual date when the holiday is celebrated, which may differ from the original date due to weekend shifts or other rules).
        /// </summary>
        public DateTime ObservedDate { get; }

        /// <summary>
        /// Gets a value indicating whether the holiday is defined by a fixed date in a year (e.g., Christmas on December 25) or a variable date (e.g., Easter).
        /// </summary>
        public bool IsFixedDate { get; }

        /// <summary>
        /// Gets the administrative divisions where this holiday is observed.
        /// Administrative divisions are geographical areas into which a country is divided, such as states (US), provinces (Canada),
        /// Bundesländer (Germany), departments (France), or other regional subdivisions.
        /// </summary>
        public T AdministrativeDivisions { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Holiday{T}"/> class.
        /// </summary>
        /// <param name="name">The internal name of the holiday.</param>
        /// <param name="originalDate">The original date of the holiday.</param>
        /// <param name="observedDate">The observed date of the holiday.</param>
        /// <param name="isFixedDate">True if the holiday is defined by a fixed date; otherwise, false.</param>
        /// <param name="administrativeDivisions">The administrative divisions where this holiday is observed.</param>
        /// <param name="resourceManager">The resource manager for localization. If null, the default resource manager is used.</param>
        protected Holiday(string name
            , DateTime originalDate
            , DateTime observedDate
            , bool isFixedDate
            , T administrativeDivisions
            , ResourceManager resourceManager = null)
        {
            this.Name = name;
            this.OriginalDate = originalDate;
            this.ObservedDate = observedDate;
            this.IsFixedDate = isFixedDate;
            this.AdministrativeDivisions = administrativeDivisions;
            _resourceManager = resourceManager ?? Resources.ResourceManager;
        }

        /// <summary>
        /// Compares the current holiday to another holiday by their observed dates.
        /// </summary>
        /// <param name="other">The holiday to compare with.</param>
        /// <returns>A value that indicates the relative order of the holidays being compared.</returns>
        public virtual int CompareTo(Holiday<T> other)
           => this.ObservedDate.Date.CompareTo(other?.ObservedDate.Date ?? DateTime.MaxValue);

        /// <summary>
        /// Determines whether the current holiday is equal to another holiday based on their observed dates.
        /// </summary>
        /// <param name="other">The holiday to compare with.</param>
        /// <returns>True if the holidays have the same observed date; otherwise, false.</returns>
        public virtual bool Equals(Holiday<T> other)
            => this.ObservedDate.Date == other?.ObservedDate.Date;

        /// <summary>
        /// Gets the localized display name of the holiday based on the specified culture.
        /// </summary>
        /// <param name="cultureInfo">The culture to use for localization. If null, the current culture is used.</param>
        /// <returns>The localized name of the holiday.</returns>
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

        /// <summary>
        /// Determines whether the holiday is observed in the specified administrative division.
        /// </summary>
        /// <param name="administrativeDivision">The administrative division to check.</param>
        /// <returns>True if the holiday is observed in the specified administrative division; otherwise, false.</returns>
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

        IEnumerable<string> IHoliday.GetAdministrativeDivisions()
        {
            var enumFields = typeof(T).GetFields(System.Reflection.BindingFlags.Static
                | System.Reflection.BindingFlags.Public);

            foreach (var enumField in enumFields)
            {
                var enumValue = (T)enumField.GetValue(null);

                if (this.IsHoliday(enumValue))
                {
                    yield return enumField.Name;
                }
            }
        }
    }
}