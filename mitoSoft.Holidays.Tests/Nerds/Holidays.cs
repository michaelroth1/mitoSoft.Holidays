using System;
using System.Collections.Generic;

namespace mitoSoft.Holidays.Tests.Nerds;

internal sealed class Holidays : Holidays<Places>
{
    public Holidays() : base("Fantasia")
    {
    }

    public override IEnumerable<Holiday<Places>> GetHolidays(int year)
    {
        yield return new Holiday(nameof(Resources.TowelDay), new DateTime(year, 5, 25), true, Places.TheKnownUniverse);
        yield return new Holiday(nameof(Resources.MayTheFourth), new DateTime(year, 5, 4), true, Places.AGalaxyFarFarAway);
    }
}