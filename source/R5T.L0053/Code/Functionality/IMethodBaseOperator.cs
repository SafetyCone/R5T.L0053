using System;
using System.Linq;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IMethodBaseOperator : IFunctionalityMarker
    {
        public Type Get_DeclaringType(MethodBase methodBase)
        {
            var output = methodBase.DeclaringType;
            return output;
        }

        public Type[] Get_GenericTypeInputs_OfDeclaringType(MethodBase methodBase)
        {
            var declaringType = this.Get_DeclaringType(methodBase);

            var output = Instances.TypeOperator.Get_GenericTypeInputs(declaringType);
            return output;
        }

        public Type[] Get_GenericTypeInputs_OfMethodOnly(MethodBase methodBase)
        {
            var allGenericTypeInputs = this.Get_GenericTypeInputs_All(methodBase);

            var declaringTypeGenericTypeInputs = this.Get_GenericTypeInputs_OfDeclaringType(methodBase);

            var output = allGenericTypeInputs
                .Except(declaringTypeGenericTypeInputs,
                    NameBasedTypeEqualityComparer.Instance)
                .ToArray();

            return output;
        }

        /// <summary>
        /// Gets all generic type inputs of the method.
        /// This includes the generic type inputs of the declaring type of the method, and the method itself.
        /// </summary>
        public Type[] Get_GenericTypeInputs_All(MethodBase methodBase)
        {
            var output = methodBase.GetGenericArguments();
            return output;
        }

        /// <summary>
        /// Gets the generic type inputs of a method.
        /// </summary>
        public Type[] Get_GenericTypeInputs(MethodBase methodBase)
        {
            var output = this.Get_GenericTypeInputs_All(methodBase);
            return output;
        }

        /// <summary>
        /// Gets all generic type parameters of the method.
        /// This includes the generic type parameters of the declaring type of the method, and the method itself.
        /// </summary>
        public Type[] Get_GenericTypeParameters_All(MethodBase methodBase)
        {
            var output = methodBase.GetGenericArguments()
                .Where(Instances.TypeOperator.Is_GenericParameter)
                .ToArray();

            return output;
        }

        public Type[] Get_GenericTypeParameters(MethodBase methodBase)
        {
            var output = this.Get_GenericTypeParameters_All(methodBase);
            return output;
        }

        public ParameterInfo[] Get_InputParameters(MethodBase methodBase)
        {
            var output = methodBase.GetParameters();
            return output;
        }

        public string Get_MethodName(MethodBase methodBase)
        {
            var output = methodBase.Name;
            return output;
        }

        /// <summary>
        /// Returns the result of <see cref="MethodBase.GetParameters()"/>.
        /// </summary>
        public ParameterInfo[] Get_Parameters(MethodBase methodBase)
        {
            // Note: parsing pointer types is not supported.
            // System.NotSupportedException: 'Parsing function pointer types in signatures is not supported.'
            var output = methodBase.GetParameters();
            return output;
        }

        /// <summary>
        /// Determines whether the method has any generic type parameters.
        /// </summary>
        public bool Is_Generic(MethodBase methodBase)
        {
            var output = methodBase.IsGenericMethod;
            return output;
        }
    }
}
