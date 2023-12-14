using System;
using System.Collections.Generic;
using System.Linq;

using R5T.L0053.Extensions;
using R5T.N0000;

using R5T.T0132;



namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IEnumerableOperator : IFunctionalityMarker,
        L0066.IEnumerableOperator
    {
        public IEnumerable<T> Append<T>(
            IEnumerable<T> enumerable,
            IEnumerable<T> appendix)
        {
            return enumerable.Concat(appendix);
        }

        /// <summary>
        /// Append to an enumerable.
        /// </summary>
        public IEnumerable<T> Append<T>(
            IEnumerable<T> enumerable,
            params T[] appendix)
        {
            return enumerable.Concat(appendix);
        }

        public IEnumerable<T> AppendIf<T>(
            IEnumerable<T> enumerable,
            bool value,
            IEnumerable<T> appendix)
        {
            var output = value
                ? Instances.EnumerableOperator.Append(enumerable, appendix)
                : enumerable
                ;

            return output;
        }

        public IEnumerable<T> AppendIf<T>(
            IEnumerable<T> enumerable,
            bool value,
            params T[] appendices)
        {
            var output = this.AppendIf(
                enumerable,
                value,
                appendices.AsEnumerable());

            return output;
        }

        public IEnumerable<T> AppendIf<T>(
            IEnumerable<T> enumerable,
            bool value,
            params Func<T>[] appendixConstructors)
        {
            var appendices = value
                ? appendixConstructors.Select(x => x())
                : Instances.EnumerableOperator.Empty<T>()
                ;

            var output = this.AppendIf(
                enumerable,
                value,
                appendices);

            return output;
        }

        public IEnumerable<T> AppendIf<T>(IEnumerable<T> enumerable,
            bool value,
            IEnumerable<T> appendixIfTrue,
            IEnumerable<T> appendixIfFalse)
        {
            var output = value
                ? Instances.EnumerableOperator.Append(enumerable, appendixIfTrue)
                : Instances.EnumerableOperator.Append(enumerable, appendixIfFalse)
            ;

            return output;
        }

        public IEnumerable<T> AppendRange<T>(IEnumerable<T> enumerable, IEnumerable<T> appendix)
        {
            return enumerable.Concat(appendix);
        }

        public IEnumerable<T> AppendRange<T>(IEnumerable<T> enumerable, Func<IEnumerable<T>> appendixGenerator)
        {
            var appendix = appendixGenerator();

            var output = this.AppendRange(enumerable, appendix);
            return output;
        }

        public IEnumerable<T> Combine<T>(
            params IEnumerable<T>[] enumerables)
        {
            var output = enumerables
                .SelectMany(enumerable => enumerable)
                ;

            return output;
        }

        public bool Contains<T>(
            IEnumerable<T> array,
            T item,
            IEqualityComparer<T> equalityComparer)
        {
            var output = array.Contains(
                item,
                equalityComparer);

            return output;
        }

        public IEnumerable<T> Concatenate<T>(IEnumerable<IEnumerable<T>> enumerables)
        {
            var output = enumerables
                .SelectMany(enumerable => enumerable)
                ;

            return output;
        }

        public IEnumerable<T> Concatenate<T>(params IEnumerable<T>[] enumerables)
        {
            var output = this.Concatenate(enumerables.AsEnumerable());
            return output;
        }

        public bool Contains<T>(
            IEnumerable<T> array,
            T item)
        {
            var output = array.Contains(item);
            return output;
        }

        public T[] Get_Distinct_KeepFirst<T, TKey>(
            IEnumerable<T> values,
            Func<T, TKey> keySelector,
            out Dictionary<TKey, T[]> duplicatesByKey)
        {
            var valuesByKey = new Dictionary<TKey, T>();
            var duplicatesByKeyList = new Dictionary<TKey, List<T>>();

            foreach (var value in values)
            {
                var key = keySelector(value);

                // Performs the "keep-first" functionality.
                var added = valuesByKey.TryAdd(key, value);
                if(!added)
                {
                    duplicatesByKeyList.Add_Value(
                        key,
                        value);
                }
            }

            duplicatesByKey = duplicatesByKeyList
                .ToDictionary(
                    x => x.Key,
                    x => x.Value.ToArray());

            var output = valuesByKey.Values.ToArray();
            return output;
        }

        public IEnumerable<T> Distinct<T>(
            IEnumerable<T> items,
            Func<T, T, bool> equalsMethod,
            Func<T, int> getHashCodeMethod)
        {
            var equalityComparer = new MethodBasedEqualityComparer<T>(
                equalsMethod,
                getHashCodeMethod);

            var output = items.Distinct(
                equalityComparer);

            return output;
        }

        public IEnumerable<T> Empty<T>()
        {
            var output = Enumerable.Empty<T>();
            return output;
        }

        /// <summary>
        /// Gets items from the input enumerable <em>except</em> where the predicate is true.
        /// <para>This can been seen as the opposite of the "where" operation.</para>
        /// </summary>
        public IEnumerable<T> Except_If<T>(
            IEnumerable<T> enumerable,
            Func<T, bool> predicate)
        {
            var output = enumerable
                .Where(x =>
                {
                    var result = predicate(x);

                    var output = !result;
                    return output;
                });

            return output;
        }

        /// <summary>
        /// Returns true if the enumerable has no elements.
        /// </summary>
        public bool Is_Empty<T>(IEnumerable<T> items)
        {
            var any = items.Any();

            // None is not-any.
            var output = !any;
            return output;
        }

        /// <summary>
        /// <para>The opposite of Any().</para>
        /// Quality-of-life overload for <see cref="Is_Empty{T}(IEnumerable{T})"/>.
        /// </summary>
        public bool None<T>(IEnumerable<T> items)
        {
            return this.Is_Empty(items);
        }

        public IEnumerable<T> OrderAlphabetically<T>(
            IEnumerable<T> items,
            Func<T, string> keySelector)
        {
            var output = items.OrderBy(keySelector);
            return output;
        }

        /// <summary>
        /// Gets all two-pair combinations.
        /// </summary>
        public (T, T)[] Get_Combinations<T>(IEnumerable<T> values)
        {
            var array = values.ToArray();

            IEnumerable<(T, T)> Internal()
            {
                var elementCount = array.Length;

                for (int i = 0; i < elementCount; i++)
                {
                    for (int j = i + 1; j < elementCount; j++)
                    {
                        var firstElement = array[i];
                        var secondElement = array[j];

                        yield return (firstElement, secondElement);
                    }
                }
            }

            var output = Internal().Now();
            return output;
        }

        public T Get_First<T>(IEnumerable<T> values)
        {
            var output = values.First();
            return output;
        }

        public T Get_Nth<T>(
            IEnumerable<T> values,
            int n)
        {
            var output = values
                .Skip(n - 1)
                .First();

            return output;
        }

        public T Get_Second<T>(IEnumerable<T> values)
        {
            var output = this.Get_Nth(values, 2);
            return output;
        }

        public IEnumerable<(T, T)> Zip<T>(
            IEnumerable<T> a,
            IEnumerable<T> b)
        {
            var output = a.Zip(
                b,
                (a, b) => (a, b));

            return output;
        }
    }
}
