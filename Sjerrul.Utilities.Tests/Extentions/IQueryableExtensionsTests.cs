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
    public class IQueryableExtensionsTests
    {
        private IList<TestObject> _unsortedItems = new List<TestObject>();
        
        [TestInitialize]
        public void Init()
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < 10; i++)
            {
                TestObject t = new TestObject
                {
                    Id = i,
                    Name = alphabet[i].ToString()
                };

                _unsortedItems.Add(t);
            }

            _unsortedItems.Shuffle();
        }

        [TestMethod]
        public void OrderBy_Integer_ShouldOrderCorrectly()
        {
            IList<TestObject> sortedItems = _unsortedItems.AsQueryable().OrderBy<TestObject>("Id").ToList();

            int id = sortedItems.First().Id;
            bool isSorted = true;

            foreach (TestObject t in sortedItems)
            {
                if (t.Id < id)
                {
                    isSorted = false;
                    id = t.Id;
                }
            }

            Assert.IsTrue(isSorted);
        }

        [TestMethod]
        public void OrderByDescending_Integer_ShouldOrderCorrectly()
        {
            IList<TestObject> sortedItems = _unsortedItems.AsQueryable().OrderByDescending<TestObject>("Id").ToList();

            int id = sortedItems.First().Id;
            bool isSorted = true;

            foreach (TestObject t in sortedItems)
            {
                if (t.Id > id)
                {
                    isSorted = false;
                    id = t.Id;
                }
            }

            Assert.IsTrue(isSorted);
        }

        [TestMethod]
        public void OrderBy_String_ShouldOrderCorrectly()
        {
            IList<TestObject> sortedItems = _unsortedItems.AsQueryable().OrderBy<TestObject>("Name").ToList();
            IList<TestObject> sortedItemsByLinq = _unsortedItems.OrderBy(x => x.Name).ToList();

            bool isSorted = true;
            for (int i = 0; i < sortedItems.Count; i++)
            {
                if (sortedItems[i] != sortedItemsByLinq[i])
                {
                    isSorted = false;
                }               
            }

            Assert.IsTrue(isSorted);
        }

        [TestMethod]
        public void OrderByDescending_String_ShouldOrderCorrectly()
        {
            IList<TestObject> sortedItems = _unsortedItems.AsQueryable().OrderByDescending<TestObject>("Name").ToList();
            IList<TestObject> sortedItemsByLinq = _unsortedItems.OrderByDescending(x => x.Name).ToList();

            bool isSorted = true;
            for (int i = 0; i < sortedItems.Count; i++)
            {
                if (sortedItems[i] != sortedItemsByLinq[i])
                {
                    isSorted = false;
                }
            }

            Assert.IsTrue(isSorted);
        }

        private class TestObject
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
