using System;
using System.Collections.Generic;

namespace mitoSoft.Holidays
{
    public interface IHolidays
    {
        IEnumerable<IHoliday> GetHolidays(int year);

        IHoliday GetHoliday(DateTime actualDate);

        bool IsHoliday(DateTime actualDate, string administrativeDivision);
    }
}