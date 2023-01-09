using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValveManagement.Common.Services
{
    public static class EnumerableExtension
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(IEnumerable<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Value = x, Index = i })
                .GroupBy(x => x.Index / chunkSize)
                .Select(g => g.Select(x => x.Value));
        }
    }
}
