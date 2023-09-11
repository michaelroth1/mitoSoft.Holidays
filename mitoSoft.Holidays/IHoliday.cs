using System;
using System.Collections.Generic;
using System.Globalization;

namespace mitoSoft.Holidays
{
    public interface IHoliday
    {
        string Name { get; }

        DateTime OriginalDate { get; }

        DateTime ObservedDate { get; }

        bool IsFixedDate { get; }

        string GetDisplayName(CultureInfo cultureInfo = null);

        bool IsHoliday(string administrativeDivision);

        IEnumerable<string> GetAdministrativeDivisions();
    }
}