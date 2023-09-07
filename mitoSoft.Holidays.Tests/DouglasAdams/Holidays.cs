using System;
using System.Collections.Generic;

namespace mitoSoft.Holidays.Tests.DouglasAdams;

internal sealed class Holidays : Holidays<Places>
{
    public override IEnumerable<Holiday<Places>> GetHolidays(int year)
    {
        yield return new Holiday(nameof(Resources.TowelDay), new DateTime(year, 5, 25), true, Places.Earth);
    }
}