using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack.NET.Utility
{
    public static class LinqExtensions
    {
        public static T Random<T>(this IList<T> source)
        {
            var random = new Random();
            return source.ElementAt(random.Next(source.Count()));
        }
    }
}
