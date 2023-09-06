using System;

namespace mitoSoft.Holidays.Germany
{
    [Flags]
    public enum GermanBundeslaender : ulong
    {
        None = 0,

        BadenWuerttemberg = 1UL << 0,
        Bayern = 1UL << 1,
        Berlin = 1UL << 2,
        Brandenburg = 1UL << 3,
        Bremen = 1UL << 4,
        Hamburg = 1UL << 5,
        Hessen = 1UL << 6,
        MecklenburgVorpommern = 1UL << 7,
        Niedersachsen = 1UL << 8,
        NordrheinWestfalen = 1UL << 9,
        RheinlandPfalz = 1UL << 10,
        Saarland = 1UL << 11,
        Sachsen = 1UL << 12,
        SachsenAnhalt = 1UL << 13,
        SchleswigHolstein = 1UL << 14,
        Thueringen = 1UL << 15,

        National = BadenWuerttemberg | Bayern | Berlin | Brandenburg | Bremen
            | Hamburg | Hessen
            | MecklenburgVorpommern
            | Niedersachsen | NordrheinWestfalen
            | RheinlandPfalz
            | Saarland | Sachsen | SachsenAnhalt | SchleswigHolstein
            | Thueringen,
    }
}