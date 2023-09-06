using System;
using System.Linq;

namespace mitoSoft.Holidays
{
    public static class DateTimeExtensions
    {
        public static Holiday<T> GetHoliday<T>(this DateTime actualDate, Holidays<T> holidays)
            where T : struct, Enum
        {
            var allHolidays = holidays.GetHolidays(actualDate.Year);

            var holiday = allHolidays.FirstOrDefault(h => h.ActualDate.Date == actualDate.Date);

            return holiday;
        }

        public static bool IsHoliday<T>(this DateTime actualDate, Holidays<T> holidays, T province)
            where T : struct, Enum
        {
            var holiday = actualDate.GetHoliday(holidays);

            var isHoliday = holiday.IsHoliday(province);

            return isHoliday;
        }

        public static bool IsHoliday<T>(this Holiday<T> holiday, T province)
            where T : struct, Enum
        {
            if (holiday == null)
            {
                return false;
            }
            else if (HasFlag(holiday.Provinces, province))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool HasFlag<T>(T sourceEnum, T targetEnum)
            where T : struct, Enum
        {
            var sourceULong = Convert.ToUInt64(sourceEnum);

            var targetULong = Convert.ToUInt64(targetEnum);

            var hasFlag = (sourceULong & targetULong) == targetULong;

            return hasFlag;
        }
    }
}