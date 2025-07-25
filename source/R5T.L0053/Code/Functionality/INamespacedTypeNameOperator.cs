using System;
using System.Linq;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface INamespacedTypeNameOperator : IFunctionalityMarker,
        L0066.INamespacedTypeNameOperator
    {
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
