using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mitoSoft.Holidays.Extensions;

namespace mitoSoft.Holidays.Tests;

[TestClass]
public sealed class GenericTests
{
    [TestMethod]
    [TestCategory("IsHoliday")]
    public void GenericInstance()
    {
        var holidays = HolidaysHelper.GetHolidays("de");

        Assert.IsNotNull(holidays);

        var date = new DateTime(2023, 12, 25);

        var holiday = holidays.GetHoliday(date);

        Assert.IsNotNull(holiday);

        holiday = date.GetHoliday(holidays);

        Assert.IsNotNull(holiday);

        Assert.IsTrue(holiday.IsHoliday("Berlin"));
        Assert.IsTrue(date.IsHoliday(holidays, "Berlin"));

        Assert.IsTrue(holidays.IsHoliday(date, "National"));
        Assert.IsTrue(date.IsHoliday(holidays, "National"));

        var allHolidays = holidays.GetHolidays(2023).ToList();

        Assert.IsNotNull(allHolidays);
        Assert.AreEqual(18, allHolidays.Count);
    }
}