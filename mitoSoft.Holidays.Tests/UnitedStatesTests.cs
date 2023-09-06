using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mitoSoft.Holidays.UnitedStates;

namespace mitoSoft.Holidays.Tests
{
    [TestClass]
    public class UnitedStatesTests
    {
        private static readonly UnitedStates.Holidays _holidays = new();

        [TestMethod]
        [TestCategory("IsHoliday")]
        public void TestChristmas()
        {
            TestChristmas(new DateTime(2020, 12, 25));
            TestChristmas(new DateTime(2021, 12, 24));
            TestChristmas(new DateTime(2022, 12, 26));
            TestChristmas(new DateTime(2023, 12, 25));
        }

        [TestMethod]
        [TestCategory("IsHoliday")]
        public void TestThanksgiving()
        {
            AssertAreEqual(new DateTime(2020, 11, 26), GetThanksgiving);
            AssertAreEqual(new DateTime(2021, 11, 25), GetThanksgiving);
            AssertAreEqual(new DateTime(2022, 11, 24), GetThanksgiving);
            AssertAreEqual(new DateTime(2023, 11, 23), GetThanksgiving);
        }

        [TestMethod]
        [TestCategory("IsHoliday")]
        public void TestMemorialDay()
        {
            AssertAreEqual(new DateTime(2020, 5, 25), GetMemorialDay);
            AssertAreEqual(new DateTime(2021, 5, 31), GetMemorialDay);
            AssertAreEqual(new DateTime(2022, 5, 30), GetMemorialDay);
            AssertAreEqual(new DateTime(2023, 5, 29), GetMemorialDay);
        }

        [TestMethod]
        [TestCategory("IsHoliday")]
        public void TestLaborDay()
        {
            AssertAreEqual(new DateTime(2020, 9, 7), GetLaborDay);
            AssertAreEqual(new DateTime(2021, 9, 6), GetLaborDay);
            AssertAreEqual(new DateTime(2022, 9, 5), GetLaborDay);
            AssertAreEqual(new DateTime(2023, 9, 4), GetLaborDay);
        }

        private static void TestChristmas(DateTime expectedActualDate)
        {
            var christmasDay = AssertAreEqual(expectedActualDate, GetChristmasDay);

            Assert.AreEqual(new DateTime(expectedActualDate.Year, 12, 25), christmasDay.OriginalDate);
        }

        private static HolidayBase<States> AssertAreEqual(DateTime expectedActualDate
            , Func<int, HolidayBase<States>> getDay)
        {
            var holiday = getDay(expectedActualDate.Year);

            Assert.AreEqual(expectedActualDate, holiday.ActualDate);

            return holiday;
        }

        private static HolidayBase<States> GetChristmasDay(int year)
            => GetHolidayDay(year, nameof(Resources.ChristmasDay));

        private static HolidayBase<States> GetThanksgiving(int year)
            => GetHolidayDay(year, nameof(Resources.ThanksgivingDay));

        private static HolidayBase<States> GetMemorialDay(int year)
            => GetHolidayDay(year, nameof(Resources.UnitedStatesMemorialDay));

        private static HolidayBase<States> GetLaborDay(int year)
            => GetHolidayDay(year, nameof(Resources.LaborDay));

        private static HolidayBase<States> GetHolidayDay(int year, string name)
            => _holidays.GetHolidays(year).First(h => h.Name == name);
    }
}