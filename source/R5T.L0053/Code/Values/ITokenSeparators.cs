using System;

using R5T.T0131;


namespace R5T.L0053
{
    [ValuesMarker]
    public partial interface ITokenSeparators : IValuesMarker
    {
        /// <summary>
        /// Used to separate the namespaced type name value from the generic type parameter count in a namespaced type name.
        /// Example: ExampleClass01`1.
        /// </summary>
        public char GenericTypeParameterCountTokenSeparator => Instances.Characters.Tick;

        /// <summary>
        /// <para>'.' (period)</para>
        /// Separates tokens in a namespaced name (namespace name, namespaced type name) from each other.
        /// </summary>
        public const char NamespaceTokenSeparator_Constant = '.';

        /// <inheritdoc cref="NamespaceTokenSeparator_Constant"/>
        public char NamespaceTokenSeparator => NamespaceTokenSeparator_Constant;
    }
}
