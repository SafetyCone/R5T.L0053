using System;
using System.Linq;

using R5T.N0000;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface ITypeOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Chooses <see cref="TypeCheckDeterminesEquality_Instance{T}(T, T, out bool)"/> as the default.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Documentation.TypeCheckDeterminesEquality" path="/summary"/>
        /// </remarks>
        public bool TypeCheckDeterminesEquality<T>(T a, T b, out bool typesAreEqual)
        {
            var output = this.TypeCheckDeterminesEquality_Instance(a, b, out typesAreEqual);
            return output;
        }

        /// <summary>
        /// Use the type returned by the <see cref="object.GetType"/> method of each instance to determine type by equality.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Documentation.TypeCheckDeterminesEquality" path="/summary"/>
        /// </remarks>
        public bool TypeCheckDeterminesEquality_Instance<T>(T a, T b, out bool typesAreEqual)
        {
            var typeA = a.GetType();
            var typeB = b.GetType();

            typesAreEqual = typeA == typeB;

            var typeDeterminesEquality = !typesAreEqual;
            return typeDeterminesEquality;
        }

        /// <summary>
		/// Verify that the <typeparamref name="TInstance"/> is a <typeparamref name="T"/>, and if so, run the action.
		/// If not, throw a runtime exception.
		/// </summary>
		public void As_Type_Verify<T, TInstance>(
            TInstance instance,
            Action<T> action)
        {
            if (instance is T instanceAsT)
            {
                Instances.ActionOperator.Run(
                    instanceAsT,
                    action);
            }
            else
            {
                throw this.Get_InstanceTypeWasTypeException<T, TInstance>();
            }
        }

        /// <inheritdoc cref="As_Type_Verify{T, TInstance}(TInstance, Action{T})"/>
        public TOut As_Type_Verify<T, TInstance, TOut>(
            TInstance instance,
            Func<T, TOut> function)
        {
            if (instance is T instanceAsT)
            {
                var output = Instances.ActionOperator.Run(
                    instanceAsT,
                    function);

                return output;
            }
            else
            {
                throw this.Get_InstanceTypeWasTypeException<T, TInstance>();
            }
        }

        public Type Get_ElementType(Type type)
        {
            var output = type.GetElementType();
            return output;
        }

        /// <summary>
        /// Note, includes the generic parameter count. Example: ExampleClass01`1.
        /// </summary>
        public string Get_Name(Type type)
        {
            var typeName = type.Name;
            return typeName;
        }

        /// <summary>
        /// For a generic type parameter, get the actual name of the type parameter (example: "T").
        /// </summary>
        public string Get_GenericTypeParameterTypeName_ActualName(Type type)
        {
            var output = type.Name;
            return output;
        }

        public Exception Get_InstanceTypeWasTypeException<T, TInstance>()
        {
            var instanceTypeName = this.Get_NamespacedTypeName<TInstance>();
            var typeName = this.Get_NamespacedTypeName<T>();

            var output = new Exception($"'{instanceTypeName}' instance was not a '{typeName}'.");
            return output;
        }

        public string Get_NamespacedTypeName<T>()
        {
            var typeOfT = typeof(T);

            var output = this.Get_NamespacedTypeName(typeOfT);
            return output;
        }

        public string Get_NamespacedTypeNameOf<T>(T value)
        {
            var typeOfValue = this.Get_TypeOf(value);

            var output = this.Get_NamespacedTypeName(typeOfValue);
            return output;
        }

        /// <summary>
        /// Includes the generic parameter count (example: R5T.T0140.ExampleClass01`1),
        /// and handles nested types (example: R5T.T0225.T000.NestedType_001_Parent+NestedType_001_Child).
        /// <para>This replicates the behavior of <see cref="Type.FullName"/>.</para>
        /// </summary>
        /// <remarks>
        /// Can handle nested types, using the nested type name separator used by <see cref="Type.FullName"/> (which is <see cref="ITokenSeparators.NestedTypeNameTokenSeparator"/>).
        /// </remarks>
        public string Get_NamespacedTypeName(Type type)
        {
            var isNestedType = this.Is_NestedType(type);
            if (isNestedType)
            {
                var parentNamespacedTypeName = this.Get_NamespacedTypeName(type.DeclaringType);

                var basicTypeName = this.Get_Name(type);

                var output = $"{parentNamespacedTypeName}{Instances.TokenSeparators.NestedTypeNameTokenSeparator}{basicTypeName}";
                return output;
            }
            else
            {
                var namespaceName = this.Get_NamespaceName(type);
                var typeName = this.Get_Name(type);

                var namespacedTypeName = Instances.NamespacedTypeNameOperator.Get_NamespacedTypeName(
                    namespaceName,
                    typeName);

                return namespacedTypeName;
            }
        }

        /// <summary>
        /// The parent of a nested type is the type's <see cref="Type.DeclaringType"/>.
        /// </summary>
        public Type Get_NestedTypeParentType(Type type)
        {
            var output = type.DeclaringType;
            return output;
        }

        /// <summary>
        /// Returns the <inheritdoc cref="Documentation.TypeNameMeansFullyQualifiedTypeName" path="/summary"/> of the type.
        /// </summary>
        public string Get_TypeName(Type type)
        {
            // The full name corresponds to our concept of type name.
            var typeName = type.FullName;
            return typeName;
        }

        public string Get_NamespaceName(Type type)
        {
            var namespaceName = type.Namespace;
            return namespaceName;
        }

        /// <inheritdoc cref="Get_TypeName(Type)"/>
        public string Get_TypeNameOf<T>()
        {
            var type = this.Get_TypeOf<T>();

            // The full name corresponds to our concept of type name.
            var typeName = this.Get_TypeName(type);
            return typeName;
        }

        /// <inheritdoc cref="Get_TypeName(Type)"/>
        public string Get_TypeNameOf<T>(T value)
        {
            var type = this.Get_TypeOf(value);

            // The full name corresponds to our concept of type name.
            var typeName = this.Get_TypeName(type);
            return typeName;
        }

        /// <summary>
		/// Gets the type of the <typeparamref name="T"/>.
		/// Note: same as the typeof() operator.
		/// </summary>
		public Type Get_TypeOf<T>()
        {
            var output = typeof(T);
            return output;
        }

        public Type Get_TypeOf<T>(T instance)
        {
            var output = instance.GetType();
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_GenericTypeInputs_NotInParents(Type)"/> as the default, since in general all we really want are the *new* generic inputs of the type.
        /// If you want all the raw generic inputs of the type, use <see cref="Get_GenericTypeInputs_OfType(Type)"/>.
        /// </summary>
        public Type[] Get_GenericTypeInputs(Type type)
        {
            var output = this.Get_GenericTypeInputs_NotInParents(type);
            return output;
        }

        /// <summary>
        /// Get generic type inputs (either arguments, which are specified types like System.String, or parameters, which are unspecified like TKey).
        /// Note: gets the generic type inputs of the type (without handling any complications due to nesting, where the type might share generic inputs from it's nested parent type).
        /// </summary>
        public Type[] Get_GenericTypeInputs_OfType(Type type)
        {
            // The GetGenericArguments() method returns both type parameters of a generic type definition,
            // and the generic type arguments of a closed generic type.
            var output = type.GetGenericArguments();
            return output;
        }

        /// <summary>
        /// Get generic type inputs (either arguments, which are specified types like System.String, or parameters, which are unspecified like TKey).
        /// Note: gets the generic type inputs of the type (without handling any complications due to nesting, where the type might share generic inputs from it's nested parent type).
        /// </summary>
        public Type[] Get_GenericTypeParameters_OfType(Type type)
        {
            var output = this.Get_GenericTypeInputs_OfType(type)
                .Where(Instances.TypeOperator.Is_GenericParameter)
                .ToArray();

            return output;
        }

        /// <summary>
        /// Get generic type inputs (either arguments, which are specified types like System.String, or parameters, which are unspecified like TKey).
        /// Note: handles any complications due to nesting, such as where the type might share generic inputs from it's nested parent type, by only returning generic types inputs that are not generic type inputs of any nested parents.
        /// </summary>
        public Type[] Get_GenericTypeInputs_NotInParents(Type type)
        {
            var genericTypeInputsOfType = this.Get_GenericTypeInputs_OfType(type);

            var isNested = this.Is_NestedType(type);
            if(isNested)
            {
                var nestedParentType = this.Get_NestedTypeParentType(type);

                // Get the generic type inputs of the parent, including any that are of the parent's parent.
                var nestedParentGenericTypeInputs = this.Get_GenericTypeInputs_OfType(nestedParentType);

                // New generic types inputs in this type that are not in the parent, which are assumed to be just those types after the generic types of the parent.
                var output = genericTypeInputsOfType.Skip(nestedParentGenericTypeInputs.Length)
                    .ToArray();

                return output;
            }
            else
            {
                // If not nested, just return all generic type inputs of the type.
                return genericTypeInputsOfType;
            }
        }

        //public Type[] Get_GenericTypeInputs_IncludingNestedParents(Type type)
        //{
        //    var genericTypeInputsOfType = this.Get_GenericTypeInputs_OfType(type);

        //    var isNested = this.Is_NestedType(type);
        //    if (isNested)
        //    {
        //        var nestedParentType = this.Get_NestedTypeParentType(type);

        //        var nestedParentGenericTypeInputs = this.Get_GenericTypeInputs_IncludingNestedParents(nestedParentType);

        //        var newGenericTypeInputs = genericTypeInputsOfType
        //            .Except(nestedParentGenericTypeInputs,
        //                NameBasedTypeEqualityComparer.Instance)
        //            .ToArray();

        //        // Generic type inputs of parents, and the new generic types inputs of this type.
        //        var output = nestedParentGenericTypeInputs
        //            .Append(newGenericTypeInputs)
        //            .Now();

        //        return output;
        //    }
        //    else
        //    {
        //        // If not nested, just return all generic type inputs of the type.
        //        return genericTypeInputsOfType;
        //    }
        //}

        /// <summary>
        /// Gets the generic type arguments of a closed generic type.
        /// </summary>
        public Type[] Get_GenericTypeArguments(Type type)
        {
            var output = this.Get_GenericTypeInputs(type)
                .Where(this.Is_GenericArgument)
                .Now();

            return output;
        }

        /// <summary>
        /// Gets the generic type parameters of a generic type definition type.
        /// </summary>
        public Type[] Get_GenericTypeParameterTypes(Type type)
        {
            // The GetGenericArguments() method returns both type parameters of a generic type definition,
            // and the generic type arguments of a closed generic type.
            // Here we assume the type is a generic type definition.
            var genericArguments = type.GetGenericArguments();

            if (type.IsNested)
            {
                var parentType = Instances.TypeOperator.Get_NestedTypeParentType(type);

                var parentGenericArguments = parentType.GetGenericArguments();

                var output = genericArguments.Except(
                    parentGenericArguments,
                    NameBasedTypeEqualityComparer.Instance)
                    .Now();

                return output;
            }
            else
            {
                var output = genericArguments;
                return output;
            }
        }

        /// <summary>
        /// <para>Returns the value of <see cref="Type.HasElementType"/>.</para>
        /// Note: not just arrays, but by-reference and pointer types also have element types.
        /// </summary>
        public bool Has_ElementType(Type type)
        {
            var output = type.HasElementType;
            return output;
        }

        /// <summary>
        /// <inheritdoc cref = "Y0000.Glossary.ForType.ClosedGeneric" path="/definition"/>
        /// </summary>
        public bool Is_ClosedGeneric(Type type)
        {
            // If the type is not at least a constructed generic type, then it cannot be a closed generic type.
            // This test will determine closed/open for all generic types with only a single type parameter: if any construction has been done to the definition, and there is only a single parameter, then the single paramter has been filled-in, meaning all parameters have been filled-in.
            var isConstructed = this.Is_ConstructedGeneric(type);
            if (!isConstructed)
            {
                return false;
            }

            // Now test all generic type inputs to see if they are specified.
            var genericTypeInputs = this.Get_GenericTypeInputs(type);

            var unspecifiedGenericTypeParameterValues = genericTypeInputs
                .Where(xTypeParameterValue => this.Is_UnspecifiedGenericTypeParameterValue(xTypeParameterValue))
                ;

            var anyUnspecifiedGenericTypeParameterValues = unspecifiedGenericTypeParameterValues.Any();

            var isClosed = !anyUnspecifiedGenericTypeParameterValues;
            return isClosed;
        }

        /// <summary>
        /// <inheritdoc cref = "Y0000.Glossary.ForType.ConstructedGeneric" path="/definition"/>
        /// </summary>
        public bool Is_ConstructedGeneric(Type type)
        {
            var isConstructed = type.IsConstructedGenericType;
            return isConstructed;
        }

        public bool Is_Generic(Type type)
        {
            var isGeneric = type.IsGenericType;
            return isGeneric;
        }

        //      /// <summary>
        ///// <inheritdoc cref = "Y0000.Glossary.ForType.GenericDefinition" path="/definition"/>
        ///// </summary>
        //public bool Is_GenericDefinition(Type type)
        //      {
        //          var isGeneric = this.Get_GenericTypeArguments(type);
        //          return isGeneric;
        //      }

        /// <summary>
        /// Returns the opposite of <see cref="Type.IsGenericParameter"/>.
        /// </summary>
        public bool Is_GenericArgument(Type type)
        {
            var isGenericParameter = this.Is_GenericParameter(type);

            var output = !isGenericParameter;
            return output;
        }

        /// <summary>
        /// Returns <see cref="Type.IsGenericParameter"/>,
        /// whic is true for both generic type parameter types and generic method parameter types.
        /// </summary>
        public bool Is_GenericParameter(Type type)
        {
            var output = type.IsGenericParameter;
            return output;
        }

        /// <summary>
        /// Is the type a type parameter of a generic type or generic method?
        /// Note: this tests for whether the type is a <em>parameter</em>, not an argument.
        /// As the clearest explanation of the difference,
        /// generic type parameters have names like "T", while generic type arguments have names like "System.Int32".
        /// </summary>
        public bool Is_GenericTypeParameter(Type type)
        {
            var output = type.IsGenericTypeParameter;
            return output;
        }

        public bool Is_GenericTypeDefinition(Type type)
        {
            var output = type.IsGenericTypeDefinition;
            return output;
        }

        public bool Is_GenericMethodParamter(Type type)
        {
            var output = type.IsGenericMethodParameter;
            return output;
        }

        public bool Is_MethodNestedType(Type type)
        {
            var output = type.DeclaringMethod is object;
            return output;
        }

        public bool Is_NestedType(Type type)
        {
            var output = type.DeclaringType is object;
            return output;
        }

        /// <summary>
		/// <inheritdoc cref = "Y0000.Glossary.ForType.OpenGeneric" path="/definition"/>
		/// </summary>
		public bool Is_OpenGeneric(Type type)
        {
            var isOpen = type.IsGenericTypeDefinition;
            return isOpen;
        }

        public bool Is_Public(Type type)
        {
            var output = type.IsPublic;
            return output;
        }

        public bool Is_UnspecifiedGenericTypeParameterValue(Type type)
        {
            var output = type.IsGenericTypeParameter;
            return output;
        }
    }
}
