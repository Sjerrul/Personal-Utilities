using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sjerrul.Utilities.Extentions
{
    public static class IntegerExtensions
    {
        public static TimeSpan Days(this int i)
        {
            return new TimeSpan(i, 0, 0, 0);
        }

        public static TimeSpan Hours(this int i)
        {
            return new TimeSpan(i, 0, 0);
        }

        public static TimeSpan Minutes(this int i)
        {
            return new TimeSpan(0, i, 0);
        }

        public static TimeSpan Seconds(this int i)
        {
            return new TimeSpan(0, 0, i);
        }
    }
}
