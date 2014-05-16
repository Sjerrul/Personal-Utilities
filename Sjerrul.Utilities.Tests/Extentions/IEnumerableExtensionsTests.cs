using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sjerrul.Utilities.Extentions;

namespace Sjerrul.Utilities.Tests.Extentions
{
    [TestClass]
    public class IEnumerableExtensionsTests
    {
        private IEnumerable<int> _tenItems;   //Even amount of items
        private IEnumerable<int> _elevenItems; //Odd amount of items
        private IEnumerable<int> _empty; //no items
 
        [TestInitialize]
        public void Init()
        {
            _tenItems = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            _elevenItems = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            _empty = new int[0];
        }


        [TestMethod]
        public void Chunk_EvenNumberOfItems_ShouldReturnCorrectAmountOfChunks()
        {
            List<List<int>> chunks = _tenItems.Chunk(5);

            Assert.AreEqual(2, chunks.Count);

            Assert.AreEqual(5, chunks[0].Count);
            Assert.AreEqual(5, chunks[1].Count);
        }

        [TestMethod]
        public void Chunk_OddNumberOfItems_ShouldReturnCorrectAmountOfChunks()
        {
            List<List<int>> chunks = _elevenItems.Chunk(5);

            Assert.AreEqual(3, chunks.Count);

            Assert.AreEqual(5, chunks[0].Count);
            Assert.AreEqual(5, chunks[1].Count);
            Assert.AreEqual(1, chunks[2].Count);
        }

        [TestMethod]
        public void Shuffle_ShouldShuffleCorrectly()
        {
            IList<int> shuffeled = _tenItems.ToList();
            shuffeled.Shuffle();

            bool isDifferent = false;

            for (int i = 0; i < shuffeled.Count(); i++)
            {
                if (_tenItems.ElementAt(0) != shuffeled.ElementAt(0))
                {
                    isDifferent = true;
                }
            }

            Assert.IsTrue(isDifferent);
        }
    }
}
