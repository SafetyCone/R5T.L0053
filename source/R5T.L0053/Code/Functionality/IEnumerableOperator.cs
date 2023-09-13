using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IEnumerableOperator : IFunctionalityMarker
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

        public bool Contains<T>(
            IEnumerable<T> array,
            T item)
        {
            var output = array.Contains(item);
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

        public IEnumerable<T> From<T>(T instance)
        {
            yield return instance;
        }

        public IEnumerable<T> From<T>(params T[] instances)
        {
            foreach (var instance in instances)
            {
                yield return instance;
            }
        }

        public IEnumerable<T> From<T>(params IEnumerable<T>[] enumerables)
        {
            var output = enumerables.SelectMany(enumerable => enumerable);
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
        /// Quality-of-life overload for <see cref="Is_Empty{T}(IEnumerable{T})"/>.
        /// </summary>
        public bool None<T>(IEnumerable<T> items)
        {
            return this.Is_Empty(items);
        }

        /// <summary>
		/// Enumerates the enumerable at the current moment.
		/// </summary>
        /// <remarks>
        /// This is a quality-of-life overload of <see cref="Enumerable.ToArray{TSource}(IEnumerable{TSource})"/>.
        /// While the method does enumerate the enumerable at the moment it is called, it's name suggests this is just a side effect.
        /// You frequently want to communicate to callers that you aver enumerating the enumerable now, not turning it into an array.
        /// </remarks>
        public T[] Now<T>(IEnumerable<T> items)
        {
            var output = items.ToArray();
            return output;
        }

        public IEnumerable<T> OrderAlphabetically<T>(
            IEnumerable<T> items,
            Func<T, string> keySelector)
        {
            var output = items.OrderBy(keySelector);
            return output;
        }
    }
}
