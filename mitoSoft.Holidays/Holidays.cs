using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace mitoSoft.Holidays
{
    /// <summary>
    /// Represents an abstract base class for a collection of holidays for a specific country with generic administrative division support.
    /// </summary>
    /// <typeparam name="T">An enum type representing the administrative divisions (e.g., states, provinces, regions) for the country.</typeparam>
    [DebuggerDisplay("{Country}")]
    public abstract class Holidays<T> : IHolidays
        where T : struct, Enum
    {
        /// <summary>
        /// Gets the name of the country for which this collection contains holidays.
        /// </summary>
        public string Country { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Holidays{T}"/> class.
        /// </summary>
        /// <param name="country">The name of the country.</param>
        protected Holidays(string country)
        {
            this.Country = country;
        }

        /// <summary>
        /// Gets all holidays for the specified year.
        /// </summary>
        /// <param name="year">The year for which to retrieve holidays.</param>
        /// <returns>An enumerable collection of holidays.</returns>
        public abstract IEnumerable<Holiday<T>> GetHolidays(int year);

        /// <summary>
        /// Gets the first holiday that falls on the specified date.
        /// </summary>
        /// <param name="actualDate">The date to check.</param>
        /// <returns>The holiday that falls on the specified date, or null if no holiday exists on that date.</returns>
        public Holiday<T> GetHoliday(DateTime actualDate)
            => this.GetHolidays(actualDate).FirstOrDefault();

        /// <summary>
        /// Gets all holidays that fall on the specified date.
        /// </summary>
        /// <param name="actualDate">The date to check.</param>
        /// <returns>An enumerable collection of holidays that fall on the specified date.</returns>
        public IEnumerable<Holiday<T>> GetHolidays(DateTime actualDate)
            => this.GetHolidays(actualDate.Year).Where(h => h.ObservedDate.Date == actualDate.Date);

        /// <summary>
        /// Determines whether the specified date is a holiday in the given administrative division.
        /// Administrative divisions are geographical areas into which a country is divided, such as states (US), provinces (Canada),
        /// Bundesländer (Germany), departments (France), or other regional subdivisions.
        /// </summary>
        /// <param name="actualDate">The date to check.</param>
        /// <param name="administrativeDivision">The administrative division to check.</param>
        /// <returns>True if the specified date is a holiday in the given administrative division; otherwise, false.</returns>
        public bool IsHoliday(DateTime actualDate, T administrativeDivision)
            => this.GetHolidays(actualDate).Any(h => h.IsHoliday(administrativeDivision));

        IHoliday IHolidays.GetHoliday(DateTime actualDate)
            => this.GetHoliday(actualDate);

        IEnumerable<IHoliday> IHolidays.GetHolidays(DateTime actualDate)
          => this.GetHolidays(actualDate);

        bool IHolidays.IsHoliday(DateTime actualDate, string administrativeDivision)
            => ((IHolidays)this).GetHolidays(actualDate).Any(h => h.IsHoliday(administrativeDivision));

        IEnumerable<IHoliday> IHolidays.GetHolidays(int year)
            => this.GetHolidays(year);

        IEnumerable<string> IHolidays.GetAdministrativeDivisions()
        {
            var enumFields = typeof(T).GetFields(System.Reflection.BindingFlags.Static
                | System.Reflection.BindingFlags.Public);

            foreach (var enumField in enumFields)
            {
                yield return enumField.Name;
            }
        }
    }
}