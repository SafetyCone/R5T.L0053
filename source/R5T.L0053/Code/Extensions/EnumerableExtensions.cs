using System;
using System.Collections.Generic;

using Instances = R5T.L0053.Instances;


namespace R5T.L0053.Extensions
{
    public static class EnumerableExtensions
    {
        
    }
}

namespace R5T.Linq
{
    public static class EnumerableExtensions
    {
        /// <inheritdoc cref="L0053.IEnumerableOperator.Except_If{T}(IEnumerable{T}, Func{T, bool})"/>
        public static IEnumerable<T> Except_If<T>(this IEnumerable<T> enumerable,
            Func<T, bool> predicate)
        {
            return Instances.EnumerableOperator.Except_If(
                enumerable,
                predicate);
        }
    }
}

namespace System.Linq
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> enumerable,
            bool value,
            Func<IEnumerable<T>> appendix_Provider)
            => Instances.EnumerableOperator.AppendIf(
                enumerable,
                value,
                appendix_Provider);

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

        public static IEnumerable<T> AppendIf_Values<T>(this IEnumerable<T> enumerable,
            bool value,
            T appendixIfTrue,
            T appendixIfFalse)
        {
            return Instances.EnumerableOperator.AppendIf_Values(enumerable,
                value,
                appendixIfTrue,
                appendixIfFalse);
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

        public static IEnumerable<T> Combine<T>(
            params IEnumerable<T>[] enumerables)
        {
            return Instances.EnumerableOperator.Combine(enumerables);
        }

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
    }
}
