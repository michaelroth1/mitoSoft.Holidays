using System;

namespace mitoSoft.Holidays.Tests.DouglasAdams;

internal sealed class Holiday : Holiday<Places>
{
    public Holiday(string name, DateTime date, bool isFixedDate, Places places)
        : base(name, date, date, isFixedDate, places, Resources.ResourceManager)
    {
    }

    public override bool IsHoliday(Places places)
        => (this.AdministrativeDivisions & places) == places;
}