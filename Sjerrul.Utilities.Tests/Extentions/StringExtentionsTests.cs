using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sjerrul.Utilities.Extentions;
using System.Collections.Generic;

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

        [TestMethod]
        public void ChunkBySimilarity_1_ReturnsCorrectList()
        {
            string input = "1";

            IList<string> result = input.ChunkBySimilarity();
            IList<string> expected = new List<string>
            {
                "1"
            };

            Assert.IsTrue(AreArraysEqual(expected, result));
        }

        [TestMethod]
        public void ChunkBySimilarity_11_ReturnsCorrectList()
        {
            string input = "11";

            IList<string> result = input.ChunkBySimilarity();
            IList<string> expected = new List<string>
            {
                "11"
            };

            Assert.IsTrue(AreArraysEqual(expected, result));
        }

        [TestMethod]
        public void ChunkBySimilarity_111_ReturnsCorrectList()
        {
            string input = "111";

            IList<string> result = input.ChunkBySimilarity();
            IList<string> expected = new List<string>
            {
                "111"
            };

            Assert.IsTrue(AreArraysEqual(expected, result));
        }

        [TestMethod]
        public void ChunkBySimilarity_12_ReturnsCorrectList()
        {
            string input = "12";

            IList<string> result = input.ChunkBySimilarity();
            IList<string> expected = new List<string>
            {
                "1",
                "2"
            };

            Assert.IsTrue(AreArraysEqual(expected, result));
        }

        [TestMethod]
        public void ChunkBySimilarity_112_ReturnsCorrectList()
        {
            string input = "112";

            IList<string> result = input.ChunkBySimilarity();
            IList<string> expected = new List<string>
            {
                "11",
                "2"
            };

            Assert.IsTrue(AreArraysEqual(expected, result));
        }

        [TestMethod]
        public void ChunkBySimilarity_1122_ReturnsCorrectList()
        {
            string input = "1122";

            IList<string> result = input.ChunkBySimilarity();
            IList<string> expected = new List<string>
            {
                "11",
                "22"
            };

            Assert.IsTrue(AreArraysEqual(expected, result));
        }

        [TestMethod]
        public void ChunkBySimilarity_112233_ReturnsCorrectList()
        {
            string input = "112233";

            IList<string> result = input.ChunkBySimilarity();
            IList<string> expected = new List<string>
            {
                "11",
                "22",
                "33"
            };

            Assert.IsTrue(AreArraysEqual(expected, result));
        }

        [TestMethod]
        public void ChunkBySimilarity_11223311_ReturnsCorrectList()
        {
            string input = "11223311";

            IList<string> result = input.ChunkBySimilarity();
            IList<string> expected = new List<string>
            {
                "11",
                "22",
                "33",
                "11"
            };

            Assert.IsTrue(AreArraysEqual(expected, result));
        }

        private bool AreArraysEqual(IList<string> array1, IList<string> array2)
        {
            if (array1.Count != array2.Count)
            {
                return false;
            }

            for (int i = 0; i < array1.Count; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
