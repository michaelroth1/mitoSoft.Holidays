using System;
using System.Collections.Generic;

namespace mitoSoft.Holidays.Germany
{
    /// <summary>
    /// https://dotnet-snippets.de/snippet/ermittlung-von-feiertagen-feiertaglogic/763
    /// https://www.feiertage.net/bundeslaender.php
    /// </summary>
    public sealed class GermanHolidays : HolidaysBase<GermanBundeslaender>
    {
        public override IEnumerable<HolidayBase<GermanBundeslaender>> GetHolidays(int year)
        {
            var easterSunday = EasterSunday.GetEasterSunday(year);

            yield return new GermanHoliday(nameof(Resources.NewYearsDay), new DateTime(year, 1, 1), true, GermanBundeslaender.National);
            yield return new GermanHoliday(nameof(Resources.Epiphany), new DateTime(year, 1, 6), true, GermanBundeslaender.BadenWuerttemberg | GermanBundeslaender.Bayern | GermanBundeslaender.SachsenAnhalt);
            yield return new GermanHoliday(nameof(Resources.InternationalWomensDay), new DateTime(year, 3, 8), true, GermanBundeslaender.Berlin);
            yield return new GermanHoliday(nameof(Resources.LaborDay), new DateTime(year, 5, 1), true, GermanBundeslaender.National);
            yield return new GermanHoliday(nameof(Resources.AssumptionOfMary), new DateTime(year, 8, 15), true, GermanBundeslaender.Saarland);
            yield return new GermanHoliday(nameof(Resources.GermanUnityDay), new DateTime(year, 10, 3), true, GermanBundeslaender.National);
            yield return new GermanHoliday(nameof(Resources.LutherRefomationDay), new DateTime(year, 10, 31), true, GermanBundeslaender.Hamburg | GermanBundeslaender.Brandenburg | GermanBundeslaender.Bremen | GermanBundeslaender.MecklenburgVorpommern | GermanBundeslaender.Niedersachsen | GermanBundeslaender.Sachsen | GermanBundeslaender.SachsenAnhalt | GermanBundeslaender.Thueringen | GermanBundeslaender.SchleswigHolstein);
            yield return new GermanHoliday(nameof(Resources.AllSaintsDay), new DateTime(year, 11, 1), true, GermanBundeslaender.Bayern | GermanBundeslaender.RheinlandPfalz | GermanBundeslaender.BadenWuerttemberg | GermanBundeslaender.Saarland | GermanBundeslaender.NordrheinWestfalen);
            yield return new GermanHoliday(nameof(Resources.ChristmasEve), new DateTime(year, 12, 24), true, GermanBundeslaender.National);
            yield return new GermanHoliday(nameof(Resources.ChristmasDay), new DateTime(year, 12, 25), true, GermanBundeslaender.National);
            yield return new GermanHoliday(nameof(Resources.BoxingDay), new DateTime(year, 12, 26), true, GermanBundeslaender.National);
            yield return new GermanHoliday(nameof(Resources.EasterSunday), easterSunday, false, GermanBundeslaender.National);
            yield return new GermanHoliday(nameof(Resources.GoodFriday), easterSunday.AddDays(-2), false, GermanBundeslaender.National);
            yield return new GermanHoliday(nameof(Resources.EasterMonday), easterSunday.AddDays(1), false, GermanBundeslaender.National);
            yield return new GermanHoliday(nameof(Resources.FeastOfTheAscension), easterSunday.AddDays(39), false, GermanBundeslaender.National);
            yield return new GermanHoliday(nameof(Resources.PentecostSunday), easterSunday.AddDays(49), false, GermanBundeslaender.National);
            yield return new GermanHoliday(nameof(Resources.WhitMonday), easterSunday.AddDays(50), false, GermanBundeslaender.National);
            yield return new GermanHoliday(nameof(Resources.FeastOfCorpusChristi), easterSunday.AddDays(60), false, GermanBundeslaender.BadenWuerttemberg | GermanBundeslaender.Bayern | GermanBundeslaender.RheinlandPfalz | GermanBundeslaender.Hessen | GermanBundeslaender.NordrheinWestfalen | GermanBundeslaender.Saarland);
        }
    }
}