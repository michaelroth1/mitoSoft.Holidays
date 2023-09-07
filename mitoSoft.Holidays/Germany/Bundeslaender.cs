using System;

namespace mitoSoft.Holidays.Germany
{
    [Flags]
    public enum Bundeslaender : ushort
    {
        None = 0,

        BadenWuerttemberg = 1 << 0,
        Bayern = 1 << 1,
        Berlin = 1 << 2,
        Brandenburg = 1 << 3,
        Bremen = 1 << 4,
        Hamburg = 1 << 5,
        Hessen = 1 << 6,
        MecklenburgVorpommern = 1 << 7,
        Niedersachsen = 1 << 8,
        NordrheinWestfalen = 1 << 9,
        RheinlandPfalz = 1 << 10,
        Saarland = 1 << 11,
        Sachsen = 1 << 12,
        SachsenAnhalt = 1 << 13,
        SchleswigHolstein = 1 << 14,
        Thueringen = 1 << 15,

        National = BadenWuerttemberg | Bayern | Berlin | Brandenburg | Bremen
            | Hamburg | Hessen
            | MecklenburgVorpommern
            | Niedersachsen | NordrheinWestfalen
            | RheinlandPfalz
            | Saarland | Sachsen | SachsenAnhalt | SchleswigHolstein
            | Thueringen,
    }
}