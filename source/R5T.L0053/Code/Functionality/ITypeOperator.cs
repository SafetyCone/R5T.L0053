using System;
using System.Linq;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface ITypeOperator : IFunctionalityMarker
    {
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

        /// <summary>
        /// Note, includes the generic parameter count. Example: ExampleClass01`1.
        /// </summary>
        public string Get_BasicTypeName(Type type)
        {
            var typeName = type.Name;
            return typeName;
        }

        /// <summary>
		/// Gets the type arguments of the type, whether or not they have values.
        /// Note: should be the same as <see cref="Get_GenericTypeParameterValues(Type)"/>.
		/// </summary>
		public Type[] Get_GenericTypeArguments(Type type)
        {
            var genericTypeParameters = type.GetGenericArguments();
            return genericTypeParameters;
        }

        /// <summary>
		/// Gets the parameter values (arguments) of the type.
        /// Note: should be the same as <see cref="Get_GenericTypeArguments(Type)"/>.
		/// Note: It is possible to fill-in an unspecified type parameter!
		/// </summary>
		public Type[] Get_GenericTypeParameterValues(Type type)
        {
            var genericTypeParameters = type.GenericTypeArguments;
            return genericTypeParameters;
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

        /// <summary>
        /// Note, includes the generic parameter count. Example: R5T.T0140.ExampleClass01`1.
        /// </summary>
        /// <remarks>
        /// Can handle nested types.
        /// </remarks>
        public string Get_NamespacedTypeName(Type type)
        {
            var isNestedType = this.Is_NestedType(type);
            if (isNestedType)
            {
                var parentNamespacedTypeName = this.Get_NamespacedTypeName(type.DeclaringType);

                var basicTypeName = this.Get_BasicTypeName(type);

                //var output = $"{parentNamespacedTypeName}+{basicTypeName}";
                var output = $"{parentNamespacedTypeName}{Instances.TokenSeparators.NamespaceTokenSeparator}{basicTypeName}";
                return output;
            }
            else
            {
                var namespaceName = this.Get_NamespaceName(type);
                var typeName = this.Get_BasicTypeName(type);

                var namespacedTypeName = Instances.NamespacedTypeNameOperator.Get_NamespacedTypeName(
                    namespaceName,
                    typeName);

                return namespacedTypeName;
            }
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

            // Now test all type parameters to see if they are specified.
            var genericTypeParameterValues = this.Get_GenericTypeParameterValues(type);

            var unspecifiedGenericTypeParameterValues = genericTypeParameterValues
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

        /// <summary>
		/// <inheritdoc cref = "Y0000.Glossary.ForType.GenericDefinition" path="/definition"/>
		/// </summary>
		public bool Is_GenericDefinition(Type type)
        {
            var isGeneric = type.IsGenericTypeDefinition;
            return isGeneric;
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
