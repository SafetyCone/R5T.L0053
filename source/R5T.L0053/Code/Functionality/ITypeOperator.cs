using System;
using System.Linq;

using R5T.N0000;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface ITypeOperator : IFunctionalityMarker,
        L0066.ITypeOperator
    {
        public bool Type_Is<T, TInstance>(TInstance instance)
        {
            var type_T = typeof(T);

            var output = this.Type_Is(
                instance,
                type_T);

            return output;
        }

        public bool Type_Is<TInstance>(
            TInstance instance,
            Type type)
        {
            var type_Instance = instance.GetType();

            var output = type_Instance == type;
            return output;
        }

        public void Verify_Type_Is<T, TInstance>(TInstance instance)
        {
            var typeIs = this.Type_Is<T, TInstance>(instance);

            if(!typeIs)
            {
                throw this.Get_InstanceTypeWasTypeException<T, TInstance>();
            }
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
                var output = Instances.FunctionOperator.Run(
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
                .ToArray();

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
