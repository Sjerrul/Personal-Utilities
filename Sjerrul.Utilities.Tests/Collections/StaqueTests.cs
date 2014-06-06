using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sjerrul.Utilities.Collections;
using System.Diagnostics;

namespace Sjerrul.Utilities.Tests.Collections
{
    [TestClass]
    public class StaqueTests
    {
        [TestMethod]
        public void Create_NoElementsAdded_CountIsZero()
        {
            Staque sut = new Staque();

            int expected = 0;
            int result = sut.Count;

            Assert.AreEqual(expected, result);


        }

        [TestMethod]
        public void Count_OneElementAdded_CountIsOne()
        {
            string test = "Test";
            Staque sut = new Staque();
            sut.Push(test);

            int expected = 1;
            int result = sut.Count;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Count_Elementremoved_CountIsZero()
        {
            string test = "Test";
            Staque sut = new Staque();
            sut.Push(test);
            sut.Pop();

            int expected = 0;
            int result = sut.Count;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Count_Pop_ShouldReturnLastAddedElement()
        {
            string expected = "Test";
            Staque sut = new Staque();

            sut.Push(expected);
            Assert.AreEqual(1, sut.Count);

            object result = sut.Pop();
            Assert.AreEqual(expected, result);
            Assert.AreEqual(0, sut.Count);
        }

        [TestMethod]
        public void Count_AddAndPopMultipleElements_ShouldReturnCorrectElements()
        {
            string string1 = "Hello";
            string string2 = "World";
            Staque sut = new Staque();

            sut.Push(string1);
            sut.Push(string2);
            Assert.AreEqual(2, sut.Count);

            object result = sut.Pop();
            Assert.AreEqual(string2, result);
            Assert.AreEqual(1, sut.Count);

            result = sut.Pop();
            Assert.AreEqual(string1, result);
            Assert.AreEqual(0, sut.Count);
        }

        [TestMethod]
        public void Count_Peek_ShouldReturnLastAddedElementWithoutRemoving()
        {
            string expected = "Test";
            Staque sut = new Staque();

            sut.Push(expected);
            Assert.AreEqual(1, sut.Count);

            object result = sut.Peek();
            Assert.AreEqual(expected, result);
            Assert.AreEqual(1, sut.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_EmptyStack_ShouldThrowExceptions()
        {
            Staque sut = new Staque();

            object result = sut.Pop();

            //Assert ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_EmptyStack_ShouldThrowExceptions()
        {
            Staque sut = new Staque();

            object result = sut.Peek();

            //Assert ExpectedException
        }

        [TestMethod]
        public void Push_DifferentObjects_ShouldWorkNormally()
        {
            Staque sut = new Staque();

            string s = "Test";
            int i = 5;

            sut.Push(s);
            sut.Push(i);

            Assert.AreEqual(i, sut.Pop());
            Assert.AreEqual(s, sut.Pop());
        }

        [TestMethod]
        public void StressTest()
        {
            Stopwatch stopWatch = new Stopwatch();

            Staque sut = new Staque();
            int numberOfElements = 5000000;
            int i = 0;

            stopWatch.Start();
            for (i = 0; i < numberOfElements; i++)
            {
                sut.Push(i);
            }
            stopWatch.Stop();
            long milliseconds = stopWatch.ElapsedMilliseconds;
            Debug.WriteLine("Pushing {0} on the Staque: {1}ms", numberOfElements, milliseconds);

            i--; //Last loop incremented i, but that never got pushed on the stack.
            stopWatch.Reset();
            stopWatch.Start();
            while (sut.Count != 0)
            {
                int result = (int)sut.Pop();
                Assert.AreEqual(i, result);
                i--;
            }
            stopWatch.Stop();
            milliseconds = stopWatch.ElapsedMilliseconds;
            Debug.WriteLine("Popping {0} from the Staque: {1}ms", numberOfElements, milliseconds);
        }
        
    }
}
