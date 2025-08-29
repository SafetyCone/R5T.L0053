using System;

using R5T.T0131;


namespace R5T.L0053
{
    [ValuesMarker]
    public partial interface ITokenSeparators : IValuesMarker,
        L0066.ITokenSeparators
    {
        /// <summary>
        /// <para>'.' (period)</para>
        /// Separates tokens in a namespaced name (namespace name, namespaced type name) from each other.
        /// </summary>
        public const char NamespaceTokenSeparator_Constant = '.';

        /// <inheritdoc cref="NamespaceTokenSeparator_Constant"/>
        public char NamespaceTokenSeparator => NamespaceTokenSeparator_Constant;

        /// <summary>
        /// <para><name>'~' (tilde)</name></para>
        /// Separates tokens in an output-type named type name from each other.
        /// </summary>
        public const char OutputTypeNameTokenSeparator_Constant = '~';

        /// <inheritdoc cref="OutputTypeNameTokenSeparator_Constant"/>
        public char OutputTypeNameTokenSeparator => OutputTypeNameTokenSeparator_Constant;
    }
}
