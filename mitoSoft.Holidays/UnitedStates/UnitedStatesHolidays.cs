using System;
using System.Collections.Generic;

namespace mitoSoft.Holidays.UnitedStates
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Federal_holidays_in_the_United_States
    /// </summary>
    public sealed class UnitedStatesHolidays : HolidaysBase<UnitedStatesStates>
    {
        public override IEnumerable<HolidayBase<UnitedStatesStates>> GetHolidays(int year)
        {
            yield return new UnitedStatesHoliday(nameof(Resources.NewYearsDay), new DateTime(year, 1, 1), true, UnitedStatesStates.National);
            yield return new UnitedStatesHoliday(nameof(Resources.MartinLutherKingJrDay), GetXthWeekDay(year, 1, DayOfWeek.Monday, 3), false, UnitedStatesStates.National);
            yield return new UnitedStatesHoliday(nameof(Resources.GeorgeWashingtonsBirthday), GetXthWeekDay(year, 2, DayOfWeek.Monday, 3), false, UnitedStatesStates.National);
            yield return new UnitedStatesHoliday(nameof(Resources.UnitedStatesMemorialDay), GetLastWeekDay(year, 5, DayOfWeek.Monday), false, UnitedStatesStates.National);
            yield return new UnitedStatesHoliday(nameof(Resources.JuneteenthNationalIndependenceDay), new DateTime(year, 6, 19), true, UnitedStatesStates.National);
            yield return new UnitedStatesHoliday(nameof(Resources.UnitedStatesIndependenceDay), new DateTime(year, 7, 4), true, UnitedStatesStates.National);
            yield return new UnitedStatesHoliday(nameof(Resources.LaborDay), GetXthWeekDay(year, 9, DayOfWeek.Monday, 1), false, UnitedStatesStates.National);

            //https://en.wikipedia.org/wiki/Indigenous_Peoples%27_Day_(United_States)#Indigenous_Peoples_Day_observers
            var columbusDayStates = UnitedStatesStates.National
                ^ UnitedStatesStates.Hawaii
                ^ UnitedStatesStates.SouthDakota
                ^ UnitedStatesStates.Alaska
                ^ UnitedStatesStates.Minnesota
                ^ UnitedStatesStates.Vermont
                ^ UnitedStatesStates.Iowa
                ^ UnitedStatesStates.NorthCarolina
                ^ UnitedStatesStates.Alabama
                ^ UnitedStatesStates.California
                ^ UnitedStatesStates.DistrictOfColumbia
                ^ UnitedStatesStates.Louisiana
                ^ UnitedStatesStates.Maine
                ^ UnitedStatesStates.Michigan
                ^ UnitedStatesStates.NewMexico
                ^ UnitedStatesStates.Oklahoma
                ^ UnitedStatesStates.Wisconsin
                ^ UnitedStatesStates.Nebraska
                ^ UnitedStatesStates.Virginia
                ^ UnitedStatesStates.Oregon
                ^ UnitedStatesStates.Texas;

            yield return new UnitedStatesHoliday(nameof(Resources.ColumbusDay), GetXthWeekDay(year, 10, DayOfWeek.Monday, 2), false, columbusDayStates);

            var indigenousPeoplesDay = UnitedStatesStates.National
                ^ columbusDayStates;

            yield return new UnitedStatesHoliday(nameof(Resources.IndigenousPeoplesDay), GetXthWeekDay(year, 10, DayOfWeek.Monday, 2), false, indigenousPeoplesDay);

            yield return new UnitedStatesHoliday(nameof(Resources.VeteransDay), new DateTime(year, 11, 11), true, UnitedStatesStates.National);
            yield return new UnitedStatesHoliday(nameof(Resources.ThanksgivingDay), GetXthWeekDay(year, 11, DayOfWeek.Thursday, 4), false, UnitedStatesStates.National);
            yield return new UnitedStatesHoliday(nameof(Resources.ChristmasDay), new DateTime(year, 12, 25), true, UnitedStatesStates.National);
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