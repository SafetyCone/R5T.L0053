using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IValueOperator : IFunctionalityMarker
    {
        public bool Is_Default<T>(T value)
        {
            T defaultValue = default;

            var equalityComparer = EqualityComparer<T>.Default;

            var output = equalityComparer.Equals(value, defaultValue);
            return output;
        }

        public bool Is_NotDefault<T>(T value)
        {
            var isDefault = this.Is_Default(value);

            var output = !isDefault;
            return output;
        }
    }
}
