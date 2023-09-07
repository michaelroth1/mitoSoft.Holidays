using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mitoSoft.Holidays.Extensions;
using mitoSoft.Holidays.UnitedStates;

namespace mitoSoft.Holidays.Tests;

[TestClass]
public sealed class UnitedStatesTests
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

    private static Holiday AssertAreEqual(DateTime expectedActualDate
        , Func<int, Holiday> getDay
        , States states = States.National)
    {
        var holiday = getDay(expectedActualDate.Year);

        Assert.AreEqual(expectedActualDate, holiday.ActualDate);
        Assert.IsTrue(expectedActualDate.IsUSHoliday(states));

        return holiday;
    }

    private static Holiday GetChristmasDay(int year)
        => GetHolidayDay(year, nameof(Resources.ChristmasDay));

    private static Holiday GetThanksgiving(int year)
        => GetHolidayDay(year, nameof(Resources.ThanksgivingDay));

    private static Holiday GetMemorialDay(int year)
        => GetHolidayDay(year, nameof(Resources.UnitedStatesMemorialDay));

    private static Holiday GetLaborDay(int year)
        => GetHolidayDay(year, nameof(Resources.LaborDay));

    private static Holiday GetHolidayDay(int year, string name)
        => (Holiday)_holidays.GetHolidays(year).First(h => h.Name == name);
}