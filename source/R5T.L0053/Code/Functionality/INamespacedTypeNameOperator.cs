using System;
using System.Linq;
using System.Net.WebSockets;
using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface INamespacedTypeNameOperator : IFunctionalityMarker
    {
        public string Combine(params string[] tokens)
        {
            if (tokens.Length < 1)
            {
                return Instances.Strings.Empty;
            }

            if (tokens.Length < 2)
            {
                return tokens.First();
            }

            var tokenSeparator = this.Get_TokenSeparator();

            var output = Instances.StringOperator.Join(
                tokenSeparator,
                tokens);

            return output;
        }

        public string Get_TokenSeparator_String()
        {
            var output = Instances.Strings.Period;
            return output;
        }

        public char Get_TokenSeparator_Character()
        {
            var output = Instances.Characters.Period;
            return output;
        }

        /// <summary>
        /// Chooses character as the default token separator type.
        /// </summary>
        public char Get_TokenSeparator()
        {
            var output = this.Get_TokenSeparator_Character();
            return output;
        }

        public string[] Get_NameParts(string namespacedTypeName)
        {
            var tokenSeparator = this.Get_TokenSeparator();

            var output = namespacedTypeName.Split(tokenSeparator);
            return output;
        }

        public string Get_NamespacedTypeName(
            string namespaceName,
            string typeName)
        {
            if (Instances.StringOperator.Is_NullOrEmpty(namespaceName))
            {
                return typeName;
            }

            var namespacedTypeName = this.Combine(namespaceName, typeName);
            return namespacedTypeName;
        }

        /// <summary>
        /// Handles generic type names.
        /// </summary>
        public string Get_NamespacedTypeName_FromFullName(string fullTypeName)
        {
            var parts = fullTypeName.Split(
                Instances.Characters.OpenBracket_Correct);

            var namespacedTypeName = parts.First();
            return namespacedTypeName;
        }

        /// <summary>
        /// Note: Can handle types in the global namespace (those where the namespaced type name is just the type name).
        /// </summary>
        public string Get_NamespaceName(string namespacedTypeName)
        {
            var tokenSeparatorChar = this.Get_TokenSeparator_Character();

            var lastTokenSeparatorIndex = namespacedTypeName.LastIndexOf(tokenSeparatorChar);
            if (Instances.IndexOperator.Is_Found(lastTokenSeparatorIndex))
            {
                var namespaceName = namespacedTypeName[..(lastTokenSeparatorIndex)];
                return namespaceName;
            }
            else
            {
                // There is no namespace name, just a type name, indicating the type is in the global namespace.
                return Instances.Strings.Empty;
            }
        }

        /// <summary>
        /// Note: Can handle types in the global namespace (those where the namespaced type name is just the type name).
        /// </summary>
        public string Get_TypeName(string namespacedTypeName)
        {
            var nameparts = this.Get_NameParts(namespacedTypeName);

            var typeName = nameparts.Last();
            return typeName;
        }

        /// <summary>
        /// Note: will remove trailing array symbols if the element type is generic.
        /// </summary>
        public string Get_Substring_Upto_GenericTypeParameterCount(string namespacedTypeName)
        {
            var indexOfGenericTypeParameterCountTokenSeparator = Instances.StringOperator.Get_IndexOf_OrNotFound(
                namespacedTypeName,
                Instances.TokenSeparators.TypeParameterCountSeparator);

            var tokenSeparatorWasFound = Instances.IndexOperator.Is_Found(indexOfGenericTypeParameterCountTokenSeparator);

            var output = tokenSeparatorWasFound
                // Get the string upto the token separator.
                ? Instances.StringOperator.Get_Substring_Upto_Exclusive(
                    indexOfGenericTypeParameterCountTokenSeparator,
                    namespacedTypeName)
                // Just the namespaced type name itself.
                : namespacedTypeName
                ;

            return output;
        }

        public string Get_Substring_After_GenericTypeParameterCount(string namespacedTypeName)
        {
            var indexOfGenericTypeParameterCountTokenSeparator = Instances.StringOperator.Get_IndexOf_OrNotFound(
                namespacedTypeName,
                Instances.TokenSeparators.TypeParameterCountSeparator);

            Instances.IndexOperator.Verify_IsFound(indexOfGenericTypeParameterCountTokenSeparator);

            var index = indexOfGenericTypeParameterCountTokenSeparator + 1;
            var characterAtIndex = namespacedTypeName[index];
            while(Instances.CharacterOperator.Is_Digit(characterAtIndex))
            {
                index++;

                if (index == namespacedTypeName.Length)
                {
                    return String.Empty;
                }

                characterAtIndex = namespacedTypeName[index];
            }

            var output = Instances.StringOperator.Get_Substring_From_Inclusive(
                index,
                namespacedTypeName);

            return output;
        }
    }
}
