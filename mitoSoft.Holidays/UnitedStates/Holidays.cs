﻿using System;
using System.Collections.Generic;

namespace mitoSoft.Holidays.UnitedStates
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Federal_holidays_in_the_United_States
    /// </summary>
    public sealed class Holidays : Holidays<States>
    {
        public Holidays() : base("United States of America")
        {
        }

        public override IEnumerable<Holiday<States>> GetHolidays(int year)
        {
            if (year < 1776 || year > 9999)
            {
                throw new ArgumentException("Invalid year");
            }

            yield return new Holiday(nameof(Resources.NewYearsDay), new DateTime(year, 1, 1), true, States.Federal);
            yield return new Holiday(nameof(Resources.MartinLutherKingJrDay), GetXthWeekDay(year, 1, DayOfWeek.Monday, 3), false, States.Federal);
            yield return new Holiday(nameof(Resources.GeorgeWashingtonsBirthday), GetXthWeekDay(year, 2, DayOfWeek.Monday, 3), false, States.Federal);
            yield return new Holiday(nameof(Resources.UnitedStatesMemorialDay), GetLastWeekDay(year, 5, DayOfWeek.Monday), false, States.Federal);
            yield return new Holiday(nameof(Resources.JuneteenthNationalIndependenceDay), new DateTime(year, 6, 19), true, States.Federal);
            yield return new Holiday(nameof(Resources.UnitedStatesIndependenceDay), new DateTime(year, 7, 4), true, States.Federal);
            yield return new Holiday(nameof(Resources.LaborDay), GetXthWeekDay(year, 9, DayOfWeek.Monday, 1), false, States.Federal);

            var columbusDayDate = GetXthWeekDay(year, 10, DayOfWeek.Monday, 2);

            yield return new Holiday(nameof(Resources.ColumbusDay), columbusDayDate, false, States.Federal);

            //https://en.wikipedia.org/wiki/Indigenous_Peoples%27_Day_(United_States)#Indigenous_Peoples_Day_observers
            var columbusDayStates = States.Federal
                ^ States.Hawaii
                ^ States.SouthDakota
                ^ States.Alaska
                ^ States.Minnesota
                ^ States.Vermont
                ^ States.Iowa
                ^ States.NorthCarolina
                ^ States.Alabama
                ^ States.California
                ^ States.DistrictOfColumbia
                ^ States.Louisiana
                ^ States.Maine
                ^ States.Michigan
                ^ States.NewMexico
                ^ States.Oklahoma
                ^ States.Wisconsin
                ^ States.Nebraska
                ^ States.Virginia
                ^ States.Oregon
                ^ States.Texas;

            var indigenousPeoplesDay = States.Federal
                ^ columbusDayStates;

            yield return new Holiday(nameof(Resources.IndigenousPeoplesDay), columbusDayDate, false, indigenousPeoplesDay);

            yield return new Holiday(nameof(Resources.VeteransDay), new DateTime(year, 11, 11), true, States.Federal);
            yield return new Holiday(nameof(Resources.ThanksgivingDay), GetXthWeekDay(year, 11, DayOfWeek.Thursday, 4), false, States.Federal);
            yield return new Holiday(nameof(Resources.ChristmasDay), new DateTime(year, 12, 25), true, States.Federal);
        }

        private static DateTime GetXthWeekDay(int year, int month, DayOfWeek weekDay, int xthWeekDay)
        {
            var weekDayCount = 0;

            var lastDayOfMonth = GetLastDayOfMonth(year, month);

            for (var day = 1; day <= lastDayOfMonth; day++)
            {
                var date = new DateTime(year, month, day);

                if (date.DayOfWeek == weekDay)
                {
                    weekDayCount++;

                    if (weekDayCount == xthWeekDay)
                    {
                        return date;
                    }
                }
            }

            throw new InvalidOperationException();
        }

        private static DateTime GetLastWeekDay(int year, int month, DayOfWeek weekDay)
        {
            var lastDayOfMonth = GetLastDayOfMonth(year, month);

            for (var day = lastDayOfMonth; day >= 1; day--)
            {
                var date = new DateTime(year, month, day);

                if (date.DayOfWeek == weekDay)
                {
                    return date;
                }
            }

            throw new InvalidOperationException();
        }

        private static int GetLastDayOfMonth(int year, int month)
            => new DateTime(year, month, 1).AddMonths(1).AddDays(-1).Day;
    }
}