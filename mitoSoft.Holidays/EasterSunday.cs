using System;

namespace mitoSoft.Holidays
{
    public static class EasterSunday
    {
        /// <summary>
        /// This algorithm is based in part on the algorithm of Oudin (1940) as quoted in
        /// "Explanatory Supplement to the Astronomical Almanac", P.Kenneth Seidelmann.
        /// </summary>
        public static DateTime Get(int year)
        {
            if (year < 1 || year > 9999)
            {
                throw new ArgumentException("Invalid year");
            }

            int goldenNumber = year % 19;

            int century = year / 100;

            int epact = GetEpact(goldenNumber, century);

            int daysToFullMoon = GetDaysToFullMoon(goldenNumber, epact);

            int weekDayOfFullMoon = GetWeekDayOfFullMoon(year, century, daysToFullMoon);

            int daysToSundayBeforeFullMoon = GetDaysToSundayBeforeFullMoon(daysToFullMoon, weekDayOfFullMoon);

            int easterMonth = GetEasterMonth(daysToSundayBeforeFullMoon);

            int easterDay = GetEasterDay(daysToSundayBeforeFullMoon, easterMonth);

            return new DateTime(year, easterMonth, easterDay);
        }

        private static int GetEasterDay(int daysToSundayBeforeFullMoon, int easterMonth)
        {
            int x = easterMonth / 4;

            int easterDay = daysToSundayBeforeFullMoon + 28 - 31 * x;

            return easterDay;
        }

        private static int GetEasterMonth(int daysToSundayBeforeFullMoon)
        {
            int x = (daysToSundayBeforeFullMoon + 40) / 44;

            int easterMonth = 3 + x;

            return easterMonth;
        }

        /// <returns>the number of days from 21 March to the Sunday on or before the Paschal full moon (a number between -6 and 28)</returns>
        private static int GetDaysToSundayBeforeFullMoon(int daysToFullMoon, int weekDayOfFullMoon)
        {
            int daysToSundayBeforeFullMoon = daysToFullMoon - weekDayOfFullMoon;

            return daysToSundayBeforeFullMoon;
        }

        /// <returns>the weekday for the Paschal full moon (0=Sunday, 1=Monday, etc.)</returns>
        private static int GetWeekDayOfFullMoon(int year, int century, int daysToFullMoon)
        {
            int x = year / 4;

            int y = century / 4;

            int weekDayOfFullMoon = (year + x + daysToFullMoon + 2 - century + y) % 7;

            return weekDayOfFullMoon;
        }

        /// <returns>the number of days from 21 March to the Paschal full moon</returns>
        private static int GetDaysToFullMoon(int goldenNumber, int epact)
        {
            int x = epact / 28;

            int y = 29 / (epact + 1);

            int z = (21 - goldenNumber) / 11;

            int daysToFullMoon = epact - x * (1 - y * z);

            return daysToFullMoon;
        }

        /// <returns>The Epact measures the age of the moon, by the number of days that passed since an official new moon on a given date.</returns>
        private static int GetEpact(int goldenNumber, int century)
        {
            int x = century / 4;

            int y = (8 * century + 13) / 25;

            int z = 19 * goldenNumber;

            int epact = (century - x - y + z + 15) % 30;

            return epact;
        }
    }
}