using System;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface ITypeNameOperator : IFunctionalityMarker,
        L0066.ITypeNameOperator
    {
        public string Append_ElementTypeRelationshipMarker(
            Type elementTypeParentType,
            string elementTypeName,
            string arraySuffix,
            string byReferenceSuffix,
            string pointerSuffix)
        {
            var output = elementTypeName;

            bool relationshipWasHandled = false;

            var isArray = elementTypeParentType.IsArray;
            if (isArray)
            {
                output += arraySuffix;

                relationshipWasHandled = true;
            }

            var isByRef = elementTypeParentType.IsByRef;
            if (isByRef)
            {
                output += byReferenceSuffix;

                relationshipWasHandled = true;
            }

            var isByPointer = elementTypeParentType.IsPointer;
            if (isByPointer)
            {
                output += pointerSuffix;

                relationshipWasHandled = true;
            }

            if (!relationshipWasHandled)
            {
                throw Instances.ExceptionOperator.Get_UnknownElementTypeRelationshipException();
            }

            return output;
        }

        public string Append_ElementTypeRelationshipMarker(
            Type elementTypeParentType,
            string elementTypeName,
            string arraySuffix,
            char byReferenceSuffix,
            char pointerSuffix)
        {
            var output = this.Append_ElementTypeRelationshipMarker(
                elementTypeParentType,
                elementTypeName,
                arraySuffix,
                byReferenceSuffix.ToString(),
                pointerSuffix.ToString());

            return output;
        }

        /// <summary>
        /// Use the type-name affixes use by <see cref="Type.FullName"/>.
        /// </summary>
        public string Append_ElementTypeRelationshipMarker(
            Type elementTypeParentType,
            string elementTypeName)
        {
            var output = this.Append_ElementTypeRelationshipMarker(
                elementTypeParentType,
                elementTypeName,
                Instances.TypeNameAffixes.Array_Suffix,
                Instances.TypeNameAffixes.ByReference_Suffix,
                Instances.TypeNameAffixes.Pointer_Suffix);

            return output;
        }

        public string Append_NestedTypeName(
            string nestedParentTypeName,
            string typeName)
        {
            var output = $"{nestedParentTypeName}{Instances.TokenSeparators.NestedTypeNameTokenSeparator}{typeName}";
            return output;
        }

        public string Append_OutputTypeName(
            string typeName,
            string outputTypeName)
        {
            var output = $"{typeName}{Instances.TokenSeparators.OutputTypeNameTokenSeparator}{outputTypeName}";
            return output;
        }

        public string Get_PositionalTypeName_ForGenericMethodParameter(Type type)
        {
            var position = type.GenericParameterPosition;

            var output = this.Get_PositionalTypeName_ForGenericMethodParameter(position);
            return output;
        }

        public string Get_PositionalTypeName_ForGenericMethodParameter(int genericTypeParameterPosition)
        {
            var output = $"{Instances.TypeNameAffixes.GenericMethodParameterType_Prefix}{genericTypeParameterPosition}";
            return output;
        }

        public string Get_PositionalTypeName_ForGenericTypeParameter(Type type)
        {
            var position = type.GenericParameterPosition;

            var output = this.Get_PositionalTypeName_ForGenericTypeParameter(position);
            return output;
        }

        public string Get_PositionalTypeName_ForGenericTypeParameter(int genericTypeParameterPosition)
        {
            var output = $"{Instances.TypeNameAffixes.GenericTypeParameterType_Prefix}{genericTypeParameterPosition}";
            return output;
        }

        public string Get_PositionalTypeName_ForGenericParameter(Type type)
        {
            // Return the position, with some prefix.
            var position = type.GenericParameterPosition;

            var isGenericTypeParameterType = type.IsGenericTypeParameter;

            var output = isGenericTypeParameterType
                ? this.Get_PositionalTypeName_ForGenericTypeParameter(position)
                // Else, assuming the type is actually a generic parameter, if it's not a generic type parameter, then it must be a generic method parameter.
                : this.Get_PositionalTypeName_ForGenericMethodParameter(position)
                ;

            return output;
        }

        public string Remove_GenericTypeParameterCount_IfPresent(string typeName)
        {
            var indexOfGenericTypeParameterCountTokenSeparator_OrNotFound = Instances.StringOperator.Get_IndexOf_OrNotFound(
                typeName,
                Instances.TokenSeparators.TypeParameterCountSeparator);

            var isFound = Instances.StringOperator.Is_Found(indexOfGenericTypeParameterCountTokenSeparator_OrNotFound);
            if(isFound)
            {
                var output = Instances.StringOperator.Get_Substring_Upto_Exclusive(
                    indexOfGenericTypeParameterCountTokenSeparator_OrNotFound,
                    typeName);

                return output;
            }
            else
            {
                // Nothing to do.
                return typeName;
            }
        }
    }
}
