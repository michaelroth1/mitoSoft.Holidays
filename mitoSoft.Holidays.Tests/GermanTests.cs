using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mitoSoft.Holidays.Extensions;

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

            Assert.AreEqual(false, date.IsGermanHoliday(GermanBundeslaender.Bremen));
        }

        [TestMethod]
        [TestCategory("IsHoliday")]
        public void TestChristmas()
        {
            var date = new DateTime(2019, 12, 25);

            Assert.AreEqual(true, date.IsGermanHoliday(GermanBundeslaender.RheinlandPfalz));
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de");
            Assert.AreEqual("1. Weihnachtstag", date.GetGermanHoliday().Name);

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr");
            Assert.AreEqual("Christmas Day", date.GetGermanHoliday().Name);

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            Assert.AreEqual("Christmas Day", date.GetGermanHoliday().Name);
        }

        [TestMethod]
        [TestCategory("IsHoliday")]
        public void TestEastern2021()
        {
            var date = new DateTime(2021, 4, 4);

            Assert.AreEqual(true, date.IsGermanHoliday(GermanBundeslaender.NordrheinWestfalen));
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