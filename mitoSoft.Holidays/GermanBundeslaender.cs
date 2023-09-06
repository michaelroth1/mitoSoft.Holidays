using System;

namespace mitoSoft.Holidays
{
    [Flags]
    public enum GermanBundeslaender : ulong
    {
        None = 0,
        BadenWuerttemberg = 1,
        Niedersachsen = 2,
        Bayern = 4,
        NordrheinWestfalen = 8,
        Berlin = 16,
        RheinlandPfalz = 32,
        Brandenburg = 64,
        Saarland = 128,
        Bremen = 256,
        Sachsen = 512,
        Hamburg = 1024,
        SachsenAnhalt = 2048,
        Hessen = 4096,
        SchleswigHolstein = 8192,
        MecklenburgVorpommern = 16384,
        Thueringen = 32768,
        National = BadenWuerttemberg | Niedersachsen | Bayern | NordrheinWestfalen | Berlin | RheinlandPfalz | Brandenburg | Saarland
            | Bremen | Sachsen | Hamburg | SachsenAnhalt | Hessen | SchleswigHolstein | MecklenburgVorpommern | Thueringen,
    }
}