using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mitoSoft.Holidays.Extensions;
using mitoSoft.Holidays.Germany;

namespace mitoSoft.Holidays.Tests;

[TestClass]
public sealed class GermanyTests
{
    [TestMethod]
    [TestCategory("IsHoliday")]
    public void TestAllSaints()
    {
        var date = new DateTime(2019, 11, 1);

        Assert.AreEqual(true, date.IsGermanHoliday(Bundeslaender.RheinlandPfalz));
        Assert.AreEqual(false, date.IsGermanHoliday(Bundeslaender.National));
        Assert.AreEqual(false, date.IsGermanHoliday(Bundeslaender.Bremen));
    }

    [TestMethod]
    [TestCategory("IsHoliday")]
    public void TestChristmas()
    {
        var date = new DateTime(2019, 12, 25);

        Assert.AreEqual(true, date.IsGermanHoliday(Bundeslaender.RheinlandPfalz));
        Assert.AreEqual(true, date.IsGermanHoliday(Bundeslaender.National));
        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de");
        Assert.AreEqual("ChristmasDay", date.GetGermanHoliday().Name);
        Assert.AreEqual("1. Weihnachtsfeiertag", date.GetGermanHoliday().GetDisplayName());
        Assert.AreEqual("1. Weihnachtsfeiertag", date.GetGermanHoliday().GetDisplayName(Thread.CurrentThread.CurrentUICulture));

        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr");
        Assert.AreEqual("ChristmasDay", date.GetGermanHoliday().Name);
        Assert.AreEqual("Christmas Day", date.GetGermanHoliday().GetDisplayName());
        Assert.AreEqual("Christmas Day", date.GetGermanHoliday().GetDisplayName(Thread.CurrentThread.CurrentUICulture));

        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
        Assert.AreEqual("ChristmasDay", date.GetGermanHoliday().Name);
        Assert.AreEqual("Christmas Day", date.GetGermanHoliday().GetDisplayName());
        Assert.AreEqual("Christmas Day", date.GetGermanHoliday().GetDisplayName(Thread.CurrentThread.CurrentUICulture));
    }

    [TestMethod]
    [TestCategory("IsHoliday")]
    public void TestEasterSunday()
    {
        TestEasterSunday(new DateTime(2020, 4, 12));
        TestEasterSunday(new DateTime(2021, 4, 4));
        TestEasterSunday(new DateTime(2022, 4, 17));
        TestEasterSunday(new DateTime(2023, 4, 9));
    }

    [TestMethod]
    [TestCategory("IsWorkday")]
    public void TestNone()
    {
        var date = new DateTime(2019, 12, 23);

        Assert.AreEqual(false, date.IsGermanHoliday(Bundeslaender.RheinlandPfalz));
    }

    [TestMethod]
    [TestCategory("RegionalHoliday")]
    public void TestRegional()
    {
        var date = new DateTime(2019, 10, 31);

        Assert.AreEqual(false, date.IsGermanHoliday(Bundeslaender.National));
        Assert.AreEqual(true, date.IsGermanHoliday(Bundeslaender.Brandenburg));
        Assert.AreEqual(false, date.IsGermanHoliday(Bundeslaender.Berlin));
    }

    [TestMethod]
    public void EnumTest()
    {
        var bundeslaender = (ushort)Bundeslaender.BadenWuerttemberg;

        Assert.AreEqual(0b_00000000_00000001U, bundeslaender);

        bundeslaender = (ushort)Bundeslaender.Thueringen;

        Assert.AreEqual(0b_10000000_00000000U, bundeslaender);

        bundeslaender = (ushort)Bundeslaender.National;

        Assert.AreEqual(0b_11111111_11111111U, bundeslaender);
    }

    private static void TestEasterSunday(DateTime date)
    {
        Assert.AreEqual(true, date.IsGermanHoliday(Bundeslaender.NordrheinWestfalen));
        Assert.AreEqual(true, date.IsGermanHoliday(Bundeslaender.National));
    }
}