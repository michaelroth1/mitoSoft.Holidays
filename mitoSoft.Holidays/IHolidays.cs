using System;
using System.Collections.Generic;

namespace mitoSoft.Holidays
{
    public interface IHolidays
    {
        string Country { get; }

        IEnumerable<IHoliday> GetHolidays(int year);

        IHoliday GetHoliday(DateTime actualDate);

        IEnumerable<IHoliday> GetHolidays(DateTime actualDate);

        bool IsHoliday(DateTime actualDate, string administrativeDivision);

        IEnumerable<string> GetAdministrativeDivisions();
    }
}