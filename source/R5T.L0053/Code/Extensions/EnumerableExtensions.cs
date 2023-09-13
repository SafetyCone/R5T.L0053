using System;
using System.Collections.Generic;

using Instances = R5T.L0053.Instances;


namespace R5T.L0053.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable,
            IEnumerable<T> appendix)
        {
            return Instances.EnumerableOperator.Append(enumerable, appendix);
        }

        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable,
            params T[] appendix)
        {
            return Instances.EnumerableOperator.Append(enumerable, appendix);
        }

        public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> enumerable,
            bool value,
            IEnumerable<T> appendix)
        {
            return Instances.EnumerableOperator.AppendIf(
                enumerable,
                value,
                appendix);
        }

        public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> enumerable,
            bool value,
            params T[] appendices)
        {
            return Instances.EnumerableOperator.AppendIf(
                enumerable,
                value,
                appendices);
        }

        /// <summary>
        /// Delays execution of the appendix constructor until after the value is true.
        /// </summary>
        public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> enumerable,
            bool value,
            params Func<T>[] appendixConstructors)
        {
            return Instances.EnumerableOperator.AppendIf(
                enumerable,
                value,
                appendixConstructors);
        }

        public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> enumerable,
            bool value,
            IEnumerable<T> appendixIfTrue,
            IEnumerable<T> appendixIfFalse)
        {
            return Instances.EnumerableOperator.AppendIf(enumerable,
                value,
                appendixIfTrue,
                appendixIfFalse);
        }

        public static IEnumerable<T> AppendRange<T>(this IEnumerable<T> enumerable,
            IEnumerable<T> appendix)
        {
            return Instances.EnumerableOperator.AppendRange(enumerable, appendix);
        }

        public static IEnumerable<T> Combine<T>(
            params IEnumerable<T>[] enumerables)
        {
            return Instances.EnumerableOperator.Combine(enumerables);
        }
    }
}

namespace System.Linq
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> items,
            Func<T, T, bool> equalsMethod,
            Func<T, int> getHashCodeMethod)
        {
            return Instances.EnumerableOperator.Distinct(
                items,
                equalsMethod,
                getHashCodeMethod);
        }

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
