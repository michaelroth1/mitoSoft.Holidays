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

        public static bool IsHoliday(this DateTime value, States state)
        {
            var holiday = value.GetHoliday();

            if (holiday == null)
            {
                return false;
            }
            else if (holiday.States.Count() == 0 || holiday.States.ToList().Any(s => s == state))
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