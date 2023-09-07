using System;
using System.Collections.Generic;
using System.Linq;

namespace mitoSoft.Holidays
{
    public abstract class Holidays<T> : IHolidays
        where T : struct, Enum
    {
        public abstract IEnumerable<Holiday<T>> GetHolidays(int year);

        public Holiday<T> GetHoliday(DateTime actualDate)
        {
            var allHolidays = this.GetHolidays(actualDate.Year);

            var holiday = allHolidays.FirstOrDefault(h => h.ActualDate.Date == actualDate.Date);

            return holiday;
        }

        public bool IsHoliday(DateTime actualDate, T administrativeDivision)
        {
            var holiday = this.GetHoliday(actualDate);

            var isHoliday = holiday?.IsHoliday(administrativeDivision) ?? false;

            return isHoliday;
        }

        IHoliday IHolidays.GetHoliday(DateTime actualDate)
            => this.GetHoliday(actualDate);

        bool IHolidays.IsHoliday(DateTime actualDate, string administrativeDivision)
        {
            var holiday = this.GetHoliday(actualDate) as IHoliday;

            var isHoliday = holiday?.IsHoliday(administrativeDivision) ?? false;

            return isHoliday;
        }

        IEnumerable<IHoliday> IHolidays.GetHolidays(int year)
            => this.GetHolidays(year);
    }
}