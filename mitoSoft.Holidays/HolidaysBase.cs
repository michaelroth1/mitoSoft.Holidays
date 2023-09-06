using System;
using System.Collections.Generic;

namespace mitoSoft.Holidays
{
    public abstract class HolidaysBase<T>
        where T : struct, Enum
    {
        public abstract IEnumerable<HolidayBase<T>> GetHolidays(int year);
    }
}