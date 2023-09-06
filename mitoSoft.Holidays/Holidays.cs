using System;
using System.Collections.Generic;

namespace mitoSoft.Holidays
{
    public abstract class Holidays<T>
        where T : struct, Enum
    {
        public abstract IEnumerable<Holiday<T>> GetHolidays(int year);
    }
}