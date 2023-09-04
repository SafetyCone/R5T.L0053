using System;
using System.Collections.Generic;

using Instances = R5T.L0053.Instances;


namespace System.Linq
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns true if the enumerable has no elements.
        /// </summary>
        public static bool Is_Empty<T>(IEnumerable<T> items)
        {
            return Instances.EnumerableOperator.Is_Empty(items);
        }

        public static bool None<T>(IEnumerable<T> items)
        {
            return Instances.EnumerableOperator.None(items);
        }

        public static T[] Now<T>(this IEnumerable<T> items)
        {
            var output = Instances.EnumerableOperator.Now(items);
            return output;
        }

        public static IEnumerable<T> OrderAlphabetically<T>(this IEnumerable<T> items,
            Func<T, string> keySelector)
        {
            var output = Instances.EnumerableOperator.OrderAlphabetically(items, keySelector);
            return output;
        }
    }
}
