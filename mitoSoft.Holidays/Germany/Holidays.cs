using System;
using System.Collections.Generic;

namespace mitoSoft.Holidays.Germany
{
    /// <summary>
    /// Provides a collection of holidays for the Federal Republic of Germany.
    /// References:
    /// https://dotnet-snippets.de/snippet/ermittlung-von-feiertagen-feiertaglogic/763
    /// https://www.feiertage.net/bundeslaender.php
    /// </summary>
    public sealed class Holidays : Holidays<Bundeslaender>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Holidays"/> class for Germany.
        /// </summary>
        public Holidays() : base("Federal Republic of Germany")
        {
        }

        /// <summary>
        /// Gets all German holidays for the specified year.
        /// </summary>
        /// <param name="year">The year for which to retrieve holidays (must be between 1949 and 9999).</param>
        /// <returns>An enumerable collection of German holidays for the specified year.</returns>
        /// <exception cref="ArgumentException">Thrown when the year is less than 1949 or greater than 9999.</exception>
        public override IEnumerable<Holiday<Bundeslaender>> GetHolidays(int year)
        {
            if (year < 1949 || year > 9999)
            {
                throw new ArgumentException("Invalid year");
            }

            var easterSunday = EasterSunday.Get(year);

            yield return new Holiday(nameof(Resources.NewYearsDay), new DateTime(year, 1, 1), true, Bundeslaender.National);
            yield return new Holiday(nameof(Resources.Epiphany), new DateTime(year, 1, 6), true, Bundeslaender.BadenWuerttemberg | Bundeslaender.Bayern | Bundeslaender.SachsenAnhalt);
            yield return new Holiday(nameof(Resources.InternationalWomensDay), new DateTime(year, 3, 8), true, Bundeslaender.Berlin);
            yield return new Holiday(nameof(Resources.LaborDay), new DateTime(year, 5, 1), true, Bundeslaender.National);
            yield return new Holiday(nameof(Resources.AssumptionOfMary), new DateTime(year, 8, 15), true, Bundeslaender.Saarland);
            yield return new Holiday(nameof(Resources.GermanUnityDay), new DateTime(year, 10, 3), true, Bundeslaender.National);
            yield return new Holiday(nameof(Resources.LutherReformationDay), new DateTime(year, 10, 31), true, Bundeslaender.Hamburg | Bundeslaender.Brandenburg | Bundeslaender.Bremen | Bundeslaender.MecklenburgVorpommern | Bundeslaender.Niedersachsen | Bundeslaender.Sachsen | Bundeslaender.SachsenAnhalt | Bundeslaender.Thueringen | Bundeslaender.SchleswigHolstein);
            yield return new Holiday(nameof(Resources.AllSaintsDay), new DateTime(year, 11, 1), true, Bundeslaender.Bayern | Bundeslaender.RheinlandPfalz | Bundeslaender.BadenWuerttemberg | Bundeslaender.Saarland | Bundeslaender.NordrheinWestfalen);
            yield return new Holiday(nameof(Resources.ChristmasEve), new DateTime(year, 12, 24), true, Bundeslaender.National);
            yield return new Holiday(nameof(Resources.ChristmasDay), new DateTime(year, 12, 25), true, Bundeslaender.National);
            yield return new Holiday(nameof(Resources.BoxingDay), new DateTime(year, 12, 26), true, Bundeslaender.National);
            yield return new Holiday(nameof(Resources.EasterSunday), easterSunday, false, Bundeslaender.National);
            yield return new Holiday(nameof(Resources.GoodFriday), easterSunday.AddDays(-2), false, Bundeslaender.National);
            yield return new Holiday(nameof(Resources.EasterMonday), easterSunday.AddDays(1), false, Bundeslaender.National);
            yield return new Holiday(nameof(Resources.FeastOfTheAscension), easterSunday.AddDays(39), false, Bundeslaender.National);
            yield return new Holiday(nameof(Resources.PentecostSunday), easterSunday.AddDays(49), false, Bundeslaender.National);
            yield return new Holiday(nameof(Resources.WhitMonday), easterSunday.AddDays(50), false, Bundeslaender.National);
            yield return new Holiday(nameof(Resources.FeastOfCorpusChristi), easterSunday.AddDays(60), false, Bundeslaender.BadenWuerttemberg | Bundeslaender.Bayern | Bundeslaender.RheinlandPfalz | Bundeslaender.Hessen | Bundeslaender.NordrheinWestfalen | Bundeslaender.Saarland);
        }
    }
}