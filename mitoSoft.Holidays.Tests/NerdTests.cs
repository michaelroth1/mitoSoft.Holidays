using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mitoSoft.Holidays.Extensions;
using mitoSoft.Holidays.Tests.Nerds;

namespace mitoSoft.Holidays.Tests;

[TestClass]
public sealed class NerdTests
{
    private static readonly Nerds.Holidays _holidays = new();

    [TestMethod]
    [TestCategory("IsHoliday")]
    public void TowelDay()
    {
        var date = new DateTime(2019, 5, 25);

        Assert.IsTrue(date.IsHoliday(_holidays, Places.Earth));
        Assert.IsTrue(date.IsHoliday(_holidays, Places.TheKnownUniverse));

        var holiday = date.GetHoliday(_holidays);

        Assert.AreEqual("Towel Day", holiday.GetDisplayName());
    }

    [TestMethod]
    [TestCategory("IsHoliday")]
    public void MayTheFourth()
    {
        var date = new DateTime(2020, 5, 4);

        Assert.IsFalse(date.IsHoliday(_holidays, Places.Earth));
        Assert.IsTrue(date.IsHoliday(_holidays, Places.AGalaxyFarFarAway));

        var holiday = date.GetHoliday(_holidays);

        Assert.AreEqual("May the 4th", holiday.GetDisplayName());
    }

    [TestMethod]
    public void EnumTest()
    {
        var places = (byte)Places.Earth;

        Assert.AreEqual(0b_00000001U, places);

        places = (byte)Places.AGalaxyFarFarAway;

        Assert.AreEqual(0b_000000100U, places);

        places = (byte)Places.TheKnownUniverse;

        Assert.AreEqual(0b_000000111U, places);
    }
}