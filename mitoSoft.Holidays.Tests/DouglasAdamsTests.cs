using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mitoSoft.Holidays.Tests
{
    [TestClass]
    public sealed class DouglasAdamsTests
    {
        private static readonly DouglasAdams.Holidays _holidays = new();

        [TestMethod]
        [TestCategory("IsHoliday")]
        public void TowelDay()
        {
            var date = new DateTime(2019, 5, 25);

            Assert.AreEqual(true, date.IsHoliday(_holidays, DouglasAdams.Places.Earth));

            var holiday = date.GetHoliday(_holidays);

            Assert.AreEqual("Towel Day", holiday.GetDisplayName());
        }
    }
}