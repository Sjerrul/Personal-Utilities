using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sjerrul.Utilities.Tests
{
    [TestClass]
    public class AlphabetTests
    {
        [TestMethod]
        public void GetLetter_ValidNumber_ShouldReturnCorrectLetter()
        {
            string letter = Alphabet.GetNthLetter(1);
            Assert.AreEqual("a", letter);

            letter = Alphabet.GetNthLetter(26);
            Assert.AreEqual("z", letter);

            letter = Alphabet.GetNthLetter(10);
            Assert.AreEqual("j", letter);
        }

        [TestMethod]
        public void GetRandomLetter_ThousandTries_ShouldNotThrowException()
        {
            for (int i = 0; i < 10000; i++)
            {
                string letter = Alphabet.GetRandomLetter();    
            }                        
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetLetter_InvalidNumber_ShouldThrowException()
        {
            string letter = Alphabet.GetNthLetter(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetLetter_InvalidNumber2_ShouldThrowException()
        {
            string letter = Alphabet.GetNthLetter(27);
        }
    }
}
