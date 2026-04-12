using System;

namespace mitoSoft.Holidays.Germany
{
    /// <summary>
    /// Represents the federal states (Bundeslaender) of Germany.
    /// This enum uses flags to allow combining multiple states.
    /// </summary>
    [Flags]
    public enum Bundeslaender : ushort
    {
        /// <summary>
        /// No state selected.
        /// </summary>
        None = 0,

        /// <summary>
        /// Baden-Wuerttemberg (BW)
        /// </summary>
        BadenWuerttemberg = 1 << 0,

        /// <summary>
        /// Bayern / Bavaria (BY)
        /// </summary>
        Bayern = 1 << 1,

        /// <summary>
        /// Berlin (BE)
        /// </summary>
        Berlin = 1 << 2,

        /// <summary>
        /// Brandenburg (BB)
        /// </summary>
        Brandenburg = 1 << 3,

        /// <summary>
        /// Bremen (HB)
        /// </summary>
        Bremen = 1 << 4,

        /// <summary>
        /// Hamburg (HH)
        /// </summary>
        Hamburg = 1 << 5,

        /// <summary>
        /// Hessen / Hesse (HE)
        /// </summary>
        Hessen = 1 << 6,

        /// <summary>
        /// Mecklenburg-Vorpommern / Mecklenburg-Western Pomerania (MV)
        /// </summary>
        MecklenburgVorpommern = 1 << 7,

        /// <summary>
        /// Niedersachsen / Lower Saxony (NI)
        /// </summary>
        Niedersachsen = 1 << 8,

        /// <summary>
        /// Nordrhein-Westfalen / North Rhine-Westphalia (NW)
        /// </summary>
        NordrheinWestfalen = 1 << 9,

        /// <summary>
        /// Rheinland-Pfalz / Rhineland-Palatinate (RP)
        /// </summary>
        RheinlandPfalz = 1 << 10,

        /// <summary>
        /// Saarland (SL)
        /// </summary>
        Saarland = 1 << 11,

        /// <summary>
        /// Sachsen / Saxony (SN)
        /// </summary>
        Sachsen = 1 << 12,

        /// <summary>
        /// Sachsen-Anhalt / Saxony-Anhalt (ST)
        /// </summary>
        SachsenAnhalt = 1 << 13,

        /// <summary>
        /// Schleswig-Holstein (SH)
        /// </summary>
        SchleswigHolstein = 1 << 14,

        /// <summary>
        /// Thueringen / Thuringia (TH)
        /// </summary>
        Thueringen = 1 << 15,

        /// <summary>
        /// All 16 federal states of Germany. Represents national holidays observed throughout the country.
        /// </summary>
        National = BadenWuerttemberg | Bayern | Berlin | Brandenburg | Bremen
            | Hamburg | Hessen
            | MecklenburgVorpommern
            | Niedersachsen | NordrheinWestfalen
            | RheinlandPfalz
            | Saarland | Sachsen | SachsenAnhalt | SchleswigHolstein
            | Thueringen,
    }
}