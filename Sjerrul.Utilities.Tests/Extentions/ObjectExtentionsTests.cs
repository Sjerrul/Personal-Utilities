using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sjerrul.Utilities.Extentions;
using System.Collections.Generic;
using Sjerrul.Utilities.Extentions;

namespace Sjerrul.Utilities.Tests.Extentions
{
    [TestClass]
    public class ObjectExtentionsTests
    {
        [TestMethod]
        public void GetPropValue_OneLevel_ShouldGetPropertyValue()
        {
            TestObject t = new TestObject
            {
                Id = 5,
                Name = "TestName"
            };

            string name = t.GetPropertyValue("Name").ToString();
            int id = (int)t.GetPropertyValue("Id");

            Assert.AreEqual("TestName", name);
            Assert.AreEqual(5, id);
        }

        [TestMethod]
        public void GetPropValue_TwoLevels_ShouldGetPropertyValue()
        {
            TestObject child = new TestObject
            {
                Id = 10,
                Name = "Child"
            };

            TestObject t = new TestObject
            {
                Id = 5,
                Name = "TestName",
                Child = child
            };

            string name = t.GetPropertyValue("Child.Name").ToString();
            int id = (int)t.GetPropertyValue("Child.Id");

            Assert.AreEqual("Child", name);
            Assert.AreEqual(10, id);
        }

        private class TestObject
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public TestObject Child { get; set; }
        }

    }
}
