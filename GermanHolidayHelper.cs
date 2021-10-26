using mitoSoft.homeNet.Holidays.Models;
using System;
using System.Collections.Generic;

namespace mitoSoft.homeNet.Holidays
{
    /// <summary>
    /// https://dotnet-snippets.de/snippet/ermittlung-von-feiertagen-feiertaglogic/763
    /// </summary>
    public static class GermanHolidayHelper
    {
        public static IEnumerable<GermanHoliday> CalculateHolidays(int year)
        {
            DateTime osterSonntag = GetOsterSonntag(year);

            yield return new GermanHoliday(true, new DateTime(year, 1, 1), "Neujahr");
            yield return new GermanHoliday(true, new DateTime(year, 1, 6), "Heilige Drei Könige");
            yield return new GermanHoliday(true, new DateTime(year, 5, 1), "Tag der Arbeit");
            yield return new GermanHoliday(true, new DateTime(year, 8, 15), "Maria Himmelfahrt");
            yield return new GermanHoliday(true, new DateTime(year, 10, 3), "Tag der dt. Einheit");
            yield return new GermanHoliday(true, new DateTime(year, 10, 31), "Reformationstag");
            yield return new GermanHoliday(true, new DateTime(year, 11, 1), "Allerheiligen ");
            yield return new GermanHoliday(true, new DateTime(year, 12, 24), "1. Weihnachtstag"); //Vorsicht eigentlich kein Feiertag
            yield return new GermanHoliday(true, new DateTime(year, 12, 25), "1. Weihnachtstag");
            yield return new GermanHoliday(true, new DateTime(year, 12, 26), "2. Weihnachtstag");
            yield return new GermanHoliday(false, osterSonntag, "Ostersonntag");
            yield return new GermanHoliday(false, osterSonntag.AddDays(-3), "Gründonnerstag");
            yield return new GermanHoliday(false, osterSonntag.AddDays(-2), "Karfreitag");
            yield return new GermanHoliday(false, osterSonntag.AddDays(1), "Ostermontag");
            yield return new GermanHoliday(false, osterSonntag.AddDays(39), "Christi Himmelfahrt");
            yield return new GermanHoliday(false, osterSonntag.AddDays(49), "Pfingstsonntag");
            yield return new GermanHoliday(false, osterSonntag.AddDays(50), "Pfingstmontag");
            yield return new GermanHoliday(false, osterSonntag.AddDays(60), "Fronleichnam");
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