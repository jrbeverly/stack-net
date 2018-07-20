using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack.NET.Utility
{
    /// <summary>A collection of extensions method for LINQ.</summary>
    public static class LinqExtensions
    {
        /// <summary>Returns a randomly selected element from a sequence.</summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return an element from.</param>
        /// <returns>An element at a random position in the source sequence.</returns>
        public static TSource Random<TSource>(this IList<TSource> source)
        {
            var random = new Random();
            return source.ElementAt(random.Next(source.Count()));
        }
    }
}