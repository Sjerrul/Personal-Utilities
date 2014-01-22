using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sjerrul.Utilities.Extentions;

namespace Sjerrul.Utilities.Tests.Extentions
{
    [TestClass]
    public class StringExtentionsTests
    {
        [TestMethod]
        public void ToNullableInt_ValidString_ShouldReturnValidNullableInt()
        {
            string s = "5";

            int? expected = new Nullable<int>(5);
            int? actual = s.ToNullableInt();

            Assert.AreEqual(expected, actual);           
        }

        [TestMethod]
        public void ToNullableInt_ValidString_ShouldReturnValidValue()
        {
            string s = "5";

            int expected = 5;
            int? actual = s.ToNullableInt();

            Assert.AreEqual(expected, actual.Value);
        }

        [TestMethod]
        public void ToInitials_ValidString_ShouldReturnValidValue()
        {
            string s = "ABC";

            string expected = "A.B.C";
            string actual = s.ToInitials();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToInitials_ValidStringWithPeriods_ShouldReturnValidValue()
        {
            string s = "AB.C";

            string expected = "A.B.C";
            string actual = s.ToInitials();

            Assert.AreEqual(expected, actual);
        }
    }
}
