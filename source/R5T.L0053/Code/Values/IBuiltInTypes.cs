using System;

using R5T.T0131;


namespace R5T.L0053
{
    /// <summary>
    /// List of the C# built-in types (primitive types).
    /// </summary>
    /// <remarks>
    /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types"/>
    /// </remarks>
    [ValuesMarker]
    public partial interface IBuiltInTypes : IValuesMarker
    {
        public Type Bool => typeof(bool);
        public Type Byte => typeof(byte);
        public Type SByte => typeof(sbyte);
        public Type Char => typeof(char);
        public Type Decimal => typeof(decimal);
        public Type Double => typeof(double);
        public Type Float => typeof(float);
        public Type Integer => typeof(int);
        public Type UInteger => typeof(uint);
        public Type Long => typeof(long);
        public Type ULong => typeof(ulong);
        public Type Short => typeof(short);
        public Type UShort => typeof(ushort);

        public Type Object => typeof(object);
        public Type String => typeof(string);
        /// <summary>
        /// <para>There is no such thing as the dynamic type (it is just the object type, with a custom dynamic attribute).</para>
        /// Use of the typeof-operator on the dynamic keyword results in a compile-time error:
        /// CS1962-The typeof operator cannot be used on the dynamic type
        /// </summary>
        /// <remarks>
        /// Sources:
        /// <para><see href="https://stackoverflow.com/questions/1598731/how-do-i-test-for-typeofdynamic"/></para>
        /// <para><see href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.dynamicattribute?view=net-7.0"/></para>
        /// </remarks>
        public Type Dynamic => throw new NotImplementedException(); // typeof(dynamic);
    }
}
