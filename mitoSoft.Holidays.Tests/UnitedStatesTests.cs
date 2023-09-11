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

    [TestMethod]
    [TestCategory("IsHoliday")]
    public void TestColumbusDay()
    {
        var date = new DateTime(2023, 10, 9);

        var holidays = _holidays.GetHolidays(date).ToList();

        Assert.AreEqual(2, holidays.Count);

        Assert.IsTrue(date.IsHoliday(_holidays, "Texas"));
        Assert.IsTrue(date.IsHoliday(_holidays, "Federal"));
    }

    [TestMethod]
    public void EnumTest()
    {
        var states = (ulong)States.Alabama;

        Assert.AreEqual(0b_00000000_00000000_00000000_00000000_00000000_00000000_00000001UL, states);

        states = (ulong)States.DistrictOfColumbia;

        Assert.AreEqual(0b_00000100_00000000_00000000_00000000_00000000_00000000_00000000UL, states);

        states = (ulong)States.Federal;

        Assert.AreEqual(0b_00000111_11111111_11111111_11111111_11111111_11111111_11111111UL, states);

        var stateNames = ((IHolidays)_holidays).GetAdministrativeDivisions().ToList();

        Assert.AreEqual(53, stateNames.Count);
    }

    private static void TestChristmas(DateTime expectedObservedDate)
    {
        var christmasDay = AssertAreEqual(expectedObservedDate, GetChristmasDay);

        Assert.AreEqual(new DateTime(expectedObservedDate.Year, 12, 25), christmasDay.OriginalDate);
    }

    private static Holiday AssertAreEqual(DateTime expectedObservedDate
        , Func<int, Holiday> getDay
        , States states = States.Federal)
    {
        var holiday = getDay(expectedObservedDate.Year);

        Assert.AreEqual(expectedObservedDate, holiday.ObservedDate);
        Assert.IsTrue(expectedObservedDate.IsUSHoliday(states));

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