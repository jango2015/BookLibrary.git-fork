using System.Collections.Generic;

namespace BookLibrary.Core.Extensions
{
    public static class Seq
    {
        public static IEnumerable<T> Create<T>(params T[] arrays)
        {
            return arrays;
        }
    }
}