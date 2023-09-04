using System;

using R5T.T0131;


namespace R5T.L0053
{
    /// <summary>
    /// These are the integral types upon which an enumeration can be based.
    /// </summary>
    [ValuesMarker]
    public partial interface IEnumerationUnderlyingTypes : IValuesMarker
    {
        /// <inheritdoc cref="IBuiltInTypes.Integer"/>
        public Type Integer => Instances.IntegralTypes.Integer;

        /// <inheritdoc cref="IBuiltInTypes.UInteger"/>
        public Type UInteger => Instances.IntegralTypes.UInteger;

        /// <inheritdoc cref="IBuiltInTypes.Long"/>
        public Type Long => Instances.IntegralTypes.Long;

        /// <inheritdoc cref="IBuiltInTypes.ULong"/>
        public Type ULong => Instances.IntegralTypes.ULong;

        /// <inheritdoc cref="IBuiltInTypes.Byte"/>
        public Type Byte => Instances.IntegralTypes.Byte;

        /// <inheritdoc cref="IBuiltInTypes.SByte"/>
        public Type SByte => Instances.IntegralTypes.SByte;

        /// <inheritdoc cref="IBuiltInTypes.Short"/>
        public Type Short => Instances.IntegralTypes.Short;

        /// <inheritdoc cref="IBuiltInTypes.UShort"/>
        public Type UShort => Instances.IntegralTypes.UShort;
    }
}
