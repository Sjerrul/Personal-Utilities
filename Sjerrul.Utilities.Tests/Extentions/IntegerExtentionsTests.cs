using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sjerrul.Utilities.Extentions;
using System.Collections.Generic;

namespace Sjerrul.Utilities.Tests.Extentions
{
    [TestClass]
    public class IntegerExtentionsTests
    {
        [TestMethod]
        public void Days_ShouldConvertIntegerInValidTimeSpan()
        {
            TimeSpan t = 20.Days();

            TimeSpan actual = new TimeSpan(20, 0, 0, 0);

            Assert.AreEqual(t, actual);
        }

        [TestMethod]
        public void Hours_ShouldConvertIntegerInValidTimeSpan()
        {
            TimeSpan t = 20.Hours();

            TimeSpan actual = new TimeSpan(20, 0, 0);

            Assert.AreEqual(t, actual);
        }

        [TestMethod]
        public void Minutes_ShouldConvertIntegerInValidTimeSpan()
        {
            TimeSpan t = 20.Minutes();

            TimeSpan actual = new TimeSpan(0, 20, 0);

            Assert.AreEqual(t, actual);
        }

        [TestMethod]
        public void Seconds_ShouldConvertIntegerInValidTimeSpan()
        {
            TimeSpan t = 20.Seconds();

            TimeSpan actual = new TimeSpan(0, 0, 20);

            Assert.AreEqual(t, actual);
        }
    }
}
