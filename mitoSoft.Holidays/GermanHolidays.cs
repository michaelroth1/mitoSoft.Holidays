using System;
using System.Collections.Generic;
using mitoSoft.Holidays.Models;

namespace mitoSoft.Holidays
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

            yield return new GermanHoliday(Properties.Resources.newyear, new DateTime(year, 1, 1), true, GermanBundeslaender.National);
            yield return new GermanHoliday(Properties.Resources.epiphany, new DateTime(year, 1, 6), true, GermanBundeslaender.BadenWuerttemberg | GermanBundeslaender.Bayern | GermanBundeslaender.SachsenAnhalt);
            yield return new GermanHoliday(Properties.Resources.internationalWomensDay, new DateTime(year, 3, 8), true, GermanBundeslaender.Berlin);
            yield return new GermanHoliday(Properties.Resources.laborDay, new DateTime(year, 5, 1), true, GermanBundeslaender.National);
            yield return new GermanHoliday(Properties.Resources.assumptionDay, new DateTime(year, 8, 15), true, GermanBundeslaender.Saarland);
            yield return new GermanHoliday(Properties.Resources.germanUnityDay, new DateTime(year, 10, 3), true, GermanBundeslaender.National);
            yield return new GermanHoliday(Properties.Resources.lutherRefomationDay, new DateTime(year, 10, 31), true, GermanBundeslaender.Hamburg | GermanBundeslaender.Brandenburg | GermanBundeslaender.Bremen | GermanBundeslaender.MecklenburgVorpommern | GermanBundeslaender.Niedersachsen | GermanBundeslaender.Sachsen | GermanBundeslaender.SachsenAnhalt | GermanBundeslaender.Thueringen | GermanBundeslaender.SchleswigHolstein);
            yield return new GermanHoliday(Properties.Resources.allSaints, new DateTime(year, 11, 1), true, GermanBundeslaender.Bayern | GermanBundeslaender.RheinlandPfalz | GermanBundeslaender.BadenWuerttemberg | GermanBundeslaender.Saarland | GermanBundeslaender.NordrheinWestfalen);
            yield return new GermanHoliday(Properties.Resources.christmasEve, new DateTime(year, 12, 24), true, GermanBundeslaender.National);
            yield return new GermanHoliday(Properties.Resources.christmasDay, new DateTime(year, 12, 25), true, GermanBundeslaender.National);
            yield return new GermanHoliday(Properties.Resources.boxingDay, new DateTime(year, 12, 26), true, GermanBundeslaender.National);
            yield return new GermanHoliday(Properties.Resources.easter, easterSunday, false, GermanBundeslaender.National);
            yield return new GermanHoliday(Properties.Resources.goodFriday, easterSunday.AddDays(-2), false, GermanBundeslaender.National);
            yield return new GermanHoliday(Properties.Resources.easterMonday, easterSunday.AddDays(1), false, GermanBundeslaender.National);
            yield return new GermanHoliday(Properties.Resources.ascensionOfChrist, easterSunday.AddDays(39), false, GermanBundeslaender.National);
            yield return new GermanHoliday(Properties.Resources.pentecostSunday, easterSunday.AddDays(49), false, GermanBundeslaender.National);
            yield return new GermanHoliday(Properties.Resources.whitMonday, easterSunday.AddDays(50), false, GermanBundeslaender.National);
            yield return new GermanHoliday(Properties.Resources.corpusChristi, easterSunday.AddDays(60), false, GermanBundeslaender.BadenWuerttemberg | GermanBundeslaender.Bayern | GermanBundeslaender.RheinlandPfalz | GermanBundeslaender.Hessen | GermanBundeslaender.NordrheinWestfalen | GermanBundeslaender.Saarland);
        }
    }
}