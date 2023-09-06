using System;
using System.Collections.Generic;

namespace mitoSoft.Holidays.Tests.DouglasAdams;
internal sealed class Holidays : Holidays<Places>
{
    public override IEnumerable<Holiday<Places>> GetHolidays(int year)
    {
        var date = new DateTime(year, 5, 25);

        yield return new Holiday<Places>(nameof(Resources.TowelDay), date, date, true, Places.Earth, Resources.ResourceManager);
    }
}