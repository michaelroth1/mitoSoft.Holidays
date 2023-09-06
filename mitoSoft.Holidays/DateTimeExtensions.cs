using System;
using System.Linq;
using mitoSoft.Holidays.Models;

namespace mitoSoft.Holidays.Extensions
{
    public static class DateTimeExtensions
    {
        public static HolidayBase<T> GetHoliday<T>(this DateTime actualDate, HolidaysBase<T> holidays)
            where T : struct, Enum
        {
            var allHolidays = holidays.GetHolidays(actualDate.Year);

            var holiday = allHolidays.FirstOrDefault(h => h.ActualDate.Date == actualDate.Date);

            return holiday;
        }

        public static bool IsHoliday<T>(this DateTime actualDate, HolidaysBase<T> holidays, T province)
            where T : struct, Enum
        {
            var holiday = actualDate.GetHoliday(holidays);

            var isHoliday = IsHoliday(holiday, province);

            return isHoliday;
        }

        public static GermanHoliday GetGermanHoliday(this DateTime actualDate)
        {
            var holiday = actualDate.GetHoliday(new GermanHolidays()) as GermanHoliday;

            return holiday;
        }

        public static bool IsGermanHoliday(this DateTime actualDate, GermanBundeslaender bundesland = GermanBundeslaender.National)
        {
            var holiday = actualDate.GetGermanHoliday();

            var isHoliday = IsHoliday(holiday, bundesland);

            return isHoliday;
        }

        private static bool IsHoliday<T>(HolidayBase<T> holiday, T province)
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

        private static bool HasFlag(Enum sourceEnum, Enum targetEnum)
        {
            if (!sourceEnum.GetType().IsEquivalentTo(targetEnum.GetType()))
            {
                throw new ArgumentException("EnumTypeDoesNotMatch");
            }

            var sourceUlong = Convert.ToUInt64(sourceEnum);

            var targetULong = Convert.ToUInt64(targetEnum);

            var hasFlag = (sourceUlong & targetULong) == targetULong;

            return hasFlag;
        }
    }
}