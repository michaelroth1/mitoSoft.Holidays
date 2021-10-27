using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using mitoSoft.Holidays.Extensions;
using System.Threading;

namespace mitoSoft.Holidays.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        [TestCategory("IsHoliday")]
        public void TestAllSaints()
        {
            var date = new DateTime(2019, 11, 1);

            Assert.AreEqual(true, date.IsHoliday(Provinces.RheinlandPfalz));

            Assert.AreEqual(false, date.IsHoliday(Provinces.Bremen));
        }

        [TestMethod]
        [TestCategory("IsHoliday")]
        public void TestChristmas()
        {
            var date = new DateTime(2019, 12, 25);

            Assert.AreEqual(true, date.IsHoliday(Provinces.RheinlandPfalz));
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de");
            Assert.AreEqual("1. Weihnachtstag", date.GetHoliday().Name);

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr");
            Assert.AreEqual("first christmas day", date.GetHoliday().Name);

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            Assert.AreEqual("first christmas day", date.GetHoliday().Name);
        }

        [TestMethod]
        [TestCategory("IsHoliday")]
        public void TestEastern2021()
        {
            var date = new DateTime(2021, 4, 4);

            Assert.AreEqual(true, date.IsHoliday(Provinces.NordrheinWestfalen));
        }

        [TestMethod]
        [TestCategory("IsWorkday")]
        public void TestNone()
        {
            var date = new DateTime(2019, 12, 23);

            Assert.AreEqual(false, date.IsHoliday(Provinces.RheinlandPfalz));
        }
    }
}
