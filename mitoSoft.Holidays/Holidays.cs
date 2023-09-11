using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace mitoSoft.Holidays
{
    [DebuggerDisplay("{Country}")]
    public abstract class Holidays<T> : IHolidays
        where T : struct, Enum
    {
        public string Country { get; }

        protected Holidays(string country)
        {
            this.Country = country;
        }

        public abstract IEnumerable<Holiday<T>> GetHolidays(int year);

        public Holiday<T> GetHoliday(DateTime actualDate)
            => this.GetHolidays(actualDate).FirstOrDefault();

        public IEnumerable<Holiday<T>> GetHolidays(DateTime actualDate)
            => this.GetHolidays(actualDate.Year).Where(h => h.ObservedDate.Date == actualDate.Date);

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