using mitoSoft.Holidays.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mitoSoft.Holidays.Extensions
{
    public static class DateTimeExtensions
    {
        public static GermanHoliday GetHoliday(this DateTime value)
        {
            var holidays = GermanHolidayHelper.CalculateHolidays(value.Year);
            var holiday = holidays.FirstOrDefault(h => h.Date.Date == value.Date);
            return holiday;
        }

        public static bool IsHoliday(this DateTime value, Provinces federalProvinces)
        {
            var holiday = value.GetHoliday();

            if (holiday == null)
            {
                return false;
            }
            else if (holiday.FederalProvinces.Count() == 0 || holiday.FederalProvinces.ToList().Any(s => s == federalProvinces))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}