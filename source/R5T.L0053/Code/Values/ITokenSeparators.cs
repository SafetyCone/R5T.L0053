using System;

using R5T.T0131;


namespace R5T.L0053
{
    [ValuesMarker]
    public partial interface ITokenSeparators : IValuesMarker
    {
        /// <summary>
        /// <para>'`1' (two back-ticks)</para>
        /// </summary>
        public const string MethodTypeParameterCountSeparator_Constant = "``";

        /// <inheritdoc cref="MethodTypeParameterCountSeparator_Constant"/>
        public string MethodTypeParameterCountSeparator => MethodTypeParameterCountSeparator_Constant;

        /// <summary>
        /// <para>'.' (period)</para>
        /// Separates tokens in a namespaced name (namespace name, namespaced type name) from each other.
        /// </summary>
        public const char NamespaceTokenSeparator_Constant = '.';

        /// <inheritdoc cref="NamespaceTokenSeparator_Constant"/>
        public char NamespaceTokenSeparator => NamespaceTokenSeparator_Constant;

        /// <summary>
        /// <para><name>'+' (plus)</name></para>
        /// Separates tokens in a nested type name (parent type name, child type name) from each other.
        /// </summary>
        public const char NestedTypeNameTokenSeparator_Constant = '+';

        /// <inheritdoc cref="NestedTypeNameTokenSeparator_Constant"/>
        public char NestedTypeNameTokenSeparator => NestedTypeNameTokenSeparator_Constant;

        /// <summary>
        /// <para><name>'~' (tilde)</name></para>
        /// Separates tokens in an output-type named type name from each other.
        /// </summary>
        public const char OutputTypeNameTokenSeparator_Constant = '~';

        /// <inheritdoc cref="OutputTypeNameTokenSeparator_Constant"/>
        public char OutputTypeNameTokenSeparator => OutputTypeNameTokenSeparator_Constant;

        /// <summary>
        /// <para><name>'&lt;' (open-angle bracket)</name></para>
        /// </summary>
        public const char TypeArgumentListOpenTokenSeparator_Constant = '<';

        /// <inheritdoc cref="TypeArgumentListOpenTokenSeparator_Constant"/>
        public char TypeArgumentListOpenTokenSeparator => TypeArgumentListOpenTokenSeparator_Constant;

        /// <summary>
        /// <para><name>'>' (close-angle bracket)</name></para>
        /// </summary>
        public const char TypeArgumentListCloseTokenSeparator_Constant = '>';

        /// <inheritdoc cref="TypeArgumentListCloseTokenSeparator_Constant"/>
        public char TypeArgumentListCloseTokenSeparator => TypeArgumentListCloseTokenSeparator_Constant;

        /// <summary>
        /// <para>'`' (back-tick)</para>
        /// Separates the namespaced type name for type names (or namespaced typed method name for method names)
        /// from the type parameter count and then the rest of the identity name value.
        /// </summary>
        public const char TypeParameterCountSeparator_Constant = '`';

        /// <inheritdoc cref="TypeParameterCountSeparator_Constant"/>
        public char TypeParameterCountSeparator => TypeParameterCountSeparator_Constant;

        public const string TypeParameterCountSeparator_String_Constant = "`";

        /// <inheritdoc cref="TypeParameterCountSeparator_String_Constant"/>
        public string TypeParameterCountSeparator_String => TypeParameterCountSeparator_String_Constant;
    }
}
