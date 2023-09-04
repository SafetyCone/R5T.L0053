using System;

using R5T.T0131;


namespace R5T.L0053
{
    [ValuesMarker]
    public partial interface ITypeSets : IValuesMarker
    {
        private static readonly Lazy<Type[]> zBuiltInTypes = new Lazy<Type[]>(() => new[]
        {
            Instances.BuiltInTypes.Bool,
            Instances.BuiltInTypes.Byte,
            Instances.BuiltInTypes.Char,
            Instances.BuiltInTypes.Decimal,
            Instances.BuiltInTypes.Double,
            Instances.BuiltInTypes.Dynamic,
            Instances.BuiltInTypes.Float,
            Instances.BuiltInTypes.Integer,
            Instances.BuiltInTypes.Long,
            Instances.BuiltInTypes.Object,
            Instances.BuiltInTypes.SByte,
            Instances.BuiltInTypes.Short,
            Instances.BuiltInTypes.String,
            Instances.BuiltInTypes.UInteger,
            Instances.BuiltInTypes.ULong,
            Instances.BuiltInTypes.UShort,
        });

        /// <summary>
        /// The set of all C# built-in types.
        /// </summary>
        public Type[] BuiltInTypes => zBuiltInTypes.Value;

        private static readonly Lazy<Type[]> zEnumerationUnderlyingTypes = new Lazy<Type[]>(() => new[]
        {
            Instances.EnumerationUnderlyingTypes.Byte,
            Instances.EnumerationUnderlyingTypes.Integer,
            Instances.EnumerationUnderlyingTypes.Long,
            Instances.EnumerationUnderlyingTypes.SByte,
            Instances.EnumerationUnderlyingTypes.Short,
            Instances.EnumerationUnderlyingTypes.UInteger,
            Instances.EnumerationUnderlyingTypes.ULong,
            Instances.EnumerationUnderlyingTypes.UShort,
        });

        /// <summary>
        /// The set of all integral types that are allowed to be the underlying type for a C# enumeration.
        /// </summary>
        public Type[] EnumerationUnderlyingTypes => zEnumerationUnderlyingTypes.Value;

        private static readonly Lazy<Type[]> zIntegralTypes = new Lazy<Type[]>(() => new[]
        {
            Instances.IntegralTypes.Byte,
            Instances.IntegralTypes.Integer,
            Instances.IntegralTypes.Long,
            Instances.IntegralTypes.SByte,
            Instances.IntegralTypes.Short,
            Instances.IntegralTypes.UInteger,
            Instances.IntegralTypes.ULong,
            Instances.IntegralTypes.UShort,
        });

        /// <summary>
        /// The set of all C# integral types.
        /// </summary>
        public Type[] IntegralTypes => zIntegralTypes.Value;
    }
}
