using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sjerrul.Utilities.Extentions
{
    public static class StringExtentions
    {
        public static int? ToNullableInt(this string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                return null;
            }

            int returnValue;
            if (Int32.TryParse(s, out returnValue))
            {
                return returnValue;
            }

            return (int?)null;
        }

        public static int ToInt(this string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                throw new ArgumentException("Cannot cast to integer, string is empty or NULL");
            }

            int returnValue;
            if (Int32.TryParse(s, out returnValue))
            {
                return returnValue;
            }

            throw new InvalidCastException(String.Format("Unable to cast string '{0}' to integer", s));
        }

        public static string ToInitials(this string s)
        {
            string normalized = s.ToUpper().Replace(".", "");

            char[] characters = normalized.ToCharArray();
            string joined = String.Join(".", characters);
            return joined;
        }

        public static string MaxLength(this string s, int maxLength, string endWith = "...")
        {
            string shortend = s.Substring(0, maxLength);

            return String.Format("{0}{1}", shortend, endWith);
        }

        public static IList<string> ChunkBySimilarity(this string s)
        {
            IList<string> retval = new List<string>();

            int index = IndexOfFirstCharacterChange(s);
            if (index < s.Length)
            {
                IList<string> t = s.Substring(index).ChunkBySimilarity();
                retval = retval.Concat(t).ToList();
            }

            retval.Insert(0, s.Substring(0, index));

            return retval;
        }

        private static int IndexOfFirstCharacterChange(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                return 0;
            }

            if (input.Length == 1)
            {
                return 1;
            }

            int index = 0;
            char current = input[index];
            index++;
            char next = input[index];

            while (current == next)
            {
                index++;
                if (index >= input.Length)
                {
                    break;
                }

                current = next;
                next = input[index];
            }

            return index;
        }
    }
}
