using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sjerrul.Utilities.Accessibility;

namespace Sjerrul.Utilities.Tests.Accessibility
{
    [TestClass]
    public class NumberReaderTests
    {
        [TestMethod]
        public void NumberReader_ValidIntNumber_ShouldConvertCorrectly()
        {
            NumberReader numberReader = new NumberReader();
            decimal number = 123m;

            string expected = "One Hundred Twenty Three";
            string actual = numberReader.Read(number);
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumberReader_ValidNegativeIntNumber_ShouldConvertCorrectly()
        {
            NumberReader numberReader = new NumberReader();
            decimal number = -123m;

            string expected = "Negative One Hundred Twenty Three";
            string actual = numberReader.Read(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumberReader_ValidFloatingNumber_ShouldConvertCorrectly()
        {
            //NumberReader numberReader = new NumberReader();
            //decimal number = -123.34m;

            //string expected = "Negative One Hundred Twenty Three Point Thirty Four";
            //string actual = numberReader.Read(number);

            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumberReader_LargeNumber_ShouldConvertCorrectly()
        {
            NumberReader numberReader = new NumberReader();
            decimal number = 12341234123m;

            string expected = "Twelve Billion, Three Hundred Fourty One Million, Two Hundred Thirty Four Thousand, One Hundred Twenty Three";
            string actual = numberReader.Read(number);

            Assert.AreEqual(expected, actual);
        }
    }
}
