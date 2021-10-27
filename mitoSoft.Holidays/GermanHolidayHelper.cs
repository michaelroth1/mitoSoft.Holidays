using mitoSoft.Holidays.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;

namespace mitoSoft.Holidays
{
    /// <summary>
    /// https://dotnet-snippets.de/snippet/ermittlung-von-feiertagen-feiertaglogic/763
    /// https://www.feiertage.net/bundeslaender.php
    /// </summary>
    internal static class GermanHolidayHelper
    {
        public static IEnumerable<GermanHoliday> CalculateHolidays(int year)
        {
            DateTime osterSonntag = GetOsterSonntag(year);

            yield return new GermanHoliday(true, new DateTime(year, 1, 1), Properties.Resources.newyear);
            yield return new GermanHoliday(true, new DateTime(year, 1, 6), Properties.Resources.holyKings, Provinces.BadenWuerttemberg, Provinces.Bayern, Provinces.SachsenAnhalt);
            yield return new GermanHoliday(true, new DateTime(year, 5, 1), Properties.Resources.laborDay);
            yield return new GermanHoliday(true, new DateTime(year, 8, 15), Properties.Resources.assumptionDay, Provinces.Saarland);
            yield return new GermanHoliday(true, new DateTime(year, 10, 3), Properties.Resources.unityDay);
            yield return new GermanHoliday(true, new DateTime(year, 10, 31), Properties.Resources.refomationDay, Provinces.Hamburg, Provinces.Brandenburg, Provinces.Bremen, Provinces.MecklenburgVorpommern, Provinces.Niedersachsen, Provinces.Sachsen, Provinces.SachsenAnhalt, Provinces.Thueringen, Provinces.SchleswigHolstein);
            yield return new GermanHoliday(true, new DateTime(year, 11, 1), Properties.Resources.allSaints, Provinces.Bayern, Provinces.RheinlandPfalz, Provinces.BadenWuerttemberg, Provinces.Saarland, Provinces.NordrheinWestfalen);
            yield return new GermanHoliday(true, new DateTime(year, 12, 24), Properties.Resources.christmasEve);
            yield return new GermanHoliday(true, new DateTime(year, 12, 25), Properties.Resources.firstChristmas);
            yield return new GermanHoliday(true, new DateTime(year, 12, 26), Properties.Resources.secondChristmas);
            yield return new GermanHoliday(false, osterSonntag, Properties.Resources.easter);
            yield return new GermanHoliday(false, osterSonntag.AddDays(-2), Properties.Resources.goodFriday);
            yield return new GermanHoliday(false, osterSonntag.AddDays(1), Properties.Resources.easterMonday);
            yield return new GermanHoliday(false, osterSonntag.AddDays(39), Properties.Resources.ascensionOfChrist);
            yield return new GermanHoliday(false, osterSonntag.AddDays(49), Properties.Resources.pentecostSunday);
            yield return new GermanHoliday(false, osterSonntag.AddDays(50), Properties.Resources.whitMonday);
            yield return new GermanHoliday(false, osterSonntag.AddDays(60), Properties.Resources.corpusChristi, Provinces.BadenWuerttemberg, Provinces.Bayern, Provinces.RheinlandPfalz, Provinces.Hessen, Provinces.NordrheinWestfalen, Provinces.Saarland);
        }

        private static DateTime GetOsterSonntag(int year)
        {
            int g, h, c, j, l, i;

            g = year % 19;
            c = year / 100;
            h = ((c - (c / 4)) - (((8 * c) + 13) / 25) + (19 * g) + 15) % 30;
            i = h - (h / 28) * (1 - (29 / (h + 1)) * ((21 - g) / 11));
            j = (year + (year / 4) + i + 2 - c + (c / 4)) % 7;

            l = i - j;
            int month = (int)(3 + ((l + 40) / 44));
            int day = (int)(l + 28 - 31 * (month / 4));

            return new DateTime(year, month, day);
        }
    }
}