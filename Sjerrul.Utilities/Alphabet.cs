using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sjerrul.Utilities
{
    public static class Alphabet
    {
        private static string _alphabet = "abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// Get's the nth letter of the alphabet
        /// </summary>
        /// <param name="index">A number between 1 and 26</param>
        /// <returns>The letter</returns>
        /// <exception cref="ArgumentException">Throws if number is not between 1 and 26</exception>
        public static string GetNthLetter(int number)
        {
            if (number < 1 || number > 26)
            {
                throw new ArgumentException("number");
            }

            return _alphabet[number - 1].ToString();
        }

        public static string GetRandomLetter()
        {
            int number = ThreadSafeRandom.ThisThreadsRandom.Next(1, 26);

            return GetNthLetter(number);
        }
    }
}
