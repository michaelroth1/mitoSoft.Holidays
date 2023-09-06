using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mitoSoft.Holidays.Germany;

namespace mitoSoft.Holidays.Tests;

[TestClass]
public sealed class GermanTests
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
    public void TestEastern2021()
    {
        var date = new DateTime(2021, 4, 4);

        Assert.AreEqual(true, date.IsGermanHoliday(Bundeslaender.NordrheinWestfalen));
        Assert.AreEqual(true, date.IsGermanHoliday(Bundeslaender.National));
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
}