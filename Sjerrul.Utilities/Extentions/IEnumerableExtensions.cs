using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sjerrul.Utilities.Extentions
{
    public static class IEnumerableExtensions
    {
        public static List<List<T>> Chunk<T>(this IEnumerable<T> items, int itemsPerChunk)
        {
            List<List<T>> chunks = items.Select((x, i) => new { Item = x, index = i }).GroupBy(x => x.index / itemsPerChunk).Select(x => x.Select(p => p.Item).ToList()).ToList();

            return chunks;
        }

        public static void Shuffle<T> (this IList<T> items)
        {
            int count = items.Count();

            while (count > 0)
            {
                count--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(count + 1);
                T item = items[k];
                items[k] = items[count];
                items[count] = item;
            }
        }

    }
}
