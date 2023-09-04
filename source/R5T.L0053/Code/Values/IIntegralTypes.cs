using System;

using R5T.T0131;


namespace R5T.L0053
{
    /// <summary>
    /// These are the integral types in the C# language.
    /// These types are useful as the basis of an enumeration.
    /// However, must enumerations are just based on the <see cref="Int32"/> type
    /// (which is the default if no integral type is specified for the enumeration).
    /// </summary>
    /// <remarks>
    /// <para><see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types"/></para>
    /// </remarks>
    [ValuesMarker]
    public partial interface IIntegralTypes : IValuesMarker
    {
        /// <inheritdoc cref="IBuiltInTypes.Integer"/>
        public Type Integer => Instances.BuiltInTypes.Integer;

        /// <inheritdoc cref="IBuiltInTypes.UInteger"/>
        public Type UInteger => Instances.BuiltInTypes.UInteger;

        /// <inheritdoc cref="IBuiltInTypes.Long"/>
        public Type Long => Instances.BuiltInTypes.Long;

        /// <inheritdoc cref="IBuiltInTypes.ULong"/>
        public Type ULong => Instances.BuiltInTypes.ULong;

        /// <inheritdoc cref="IBuiltInTypes.Byte"/>
        public Type Byte => Instances.BuiltInTypes.Byte;

        /// <inheritdoc cref="IBuiltInTypes.SByte"/>
        public Type SByte => Instances.BuiltInTypes.SByte;

        /// <inheritdoc cref="IBuiltInTypes.Short"/>
        public Type Short => Instances.BuiltInTypes.Short;

        /// <inheritdoc cref="IBuiltInTypes.UShort"/>
        public Type UShort => Instances.BuiltInTypes.UShort;
    }
}
