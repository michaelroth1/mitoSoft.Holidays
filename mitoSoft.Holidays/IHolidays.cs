using System;
using System.Collections.Generic;

namespace mitoSoft.Holidays
{
    public interface IHolidays
    {
        string Country { get; }

        IEnumerable<IHoliday> GetHolidays(int year);

        IHoliday GetHoliday(DateTime actualDate);

        bool IsHoliday(DateTime actualDate, string administrativeDivision);
    }
}