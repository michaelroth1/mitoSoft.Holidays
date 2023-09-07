using System;
using System.Globalization;

namespace mitoSoft.Holidays
{
    public interface IHoliday
    {
        string Name { get; }

        DateTime OriginalDate { get; }

        DateTime ActualDate { get; }

        bool IsFixedDate { get; }

        string GetDisplayName(CultureInfo cultureInfo = null);

        bool IsHoliday(string administrativeDivision);
    }
}