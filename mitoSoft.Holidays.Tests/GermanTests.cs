using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mitoSoft.Holidays.Germany;

namespace mitoSoft.Holidays.Tests
{
    [TestClass]
    public class GermanTests
    {
        [TestMethod]
        [TestCategory("IsHoliday")]
        public void TestAllSaints()
        {
            var date = new DateTime(2019, 11, 1);

            Assert.AreEqual(true, date.IsGermanHoliday(GermanBundeslaender.RheinlandPfalz));
            Assert.AreEqual(false, date.IsGermanHoliday(GermanBundeslaender.National));
            Assert.AreEqual(false, date.IsGermanHoliday(GermanBundeslaender.Bremen));
        }

        [TestMethod]
        [TestCategory("IsHoliday")]
        public void TestChristmas()
        {
            var date = new DateTime(2019, 12, 25);

            Assert.AreEqual(true, date.IsGermanHoliday(GermanBundeslaender.RheinlandPfalz));
            Assert.AreEqual(true, date.IsGermanHoliday(GermanBundeslaender.National));
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

            Assert.AreEqual(true, date.IsGermanHoliday(GermanBundeslaender.NordrheinWestfalen));
            Assert.AreEqual(true, date.IsGermanHoliday(GermanBundeslaender.National));
        }

        [TestMethod]
        [TestCategory("IsWorkday")]
        public void TestNone()
        {
            var date = new DateTime(2019, 12, 23);

            Assert.AreEqual(false, date.IsGermanHoliday(GermanBundeslaender.RheinlandPfalz));
        }

        [TestMethod]
        [TestCategory("RegionalHoliday")]
        public void TestRegional()
        {
            var date = new DateTime(2019, 10, 31);

            Assert.AreEqual(false, date.IsGermanHoliday(GermanBundeslaender.National));
            Assert.AreEqual(true, date.IsGermanHoliday(GermanBundeslaender.Brandenburg));
            Assert.AreEqual(false, date.IsGermanHoliday(GermanBundeslaender.Berlin));
        }
    }
}