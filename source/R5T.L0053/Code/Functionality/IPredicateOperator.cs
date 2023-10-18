using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IPredicateOperator : IFunctionalityMarker
    {
        /// <summary>
        /// <inheritdoc cref="Get_Equals{T}(T)" path="/summary"/>
        /// This implementation is optimized for types implementing <see cref="IEquatable{T}"/>.
        /// </summary>
        public Func<T, bool> Get_Equals_ForEquatable<T>(T value)
            where T: IEquatable<T>
        {
            bool Internal(T input)
            {
                var output = input.Equals(value);
                return output;
            }

            return Internal;
        }

        /// <inheritdoc cref="Get_Equals{T}(T)"/>
        public Func<T, bool> Get_Equals<T>(
            T value,
            IEqualityComparer<T> equalityComparer)
        {
            bool Internal(T input)
            {
                var output = equalityComparer.Equals(input, value);
                return output;
            }

            return Internal;
        }

        /// <summary>
        /// Gets a predicate that captures the input value and tests whether other values are equal to the value.
        /// </summary>
        public Func<T, bool> Get_Equals<T>(T value)
        {
            var equalityComparer = EqualityComparer<T>.Default;

            return this.Get_Equals(
                value,
                equalityComparer);
        }
    }
}
