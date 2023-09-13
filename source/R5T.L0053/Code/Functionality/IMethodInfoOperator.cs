using System;
using System.Linq;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IMethodInfoOperator : IFunctionalityMarker
    {
        public ParameterInfo[] Get_InputParameters(MethodInfo methodInfo)
        {
            var output = methodInfo.GetParameters();
            return output;
        }

        public int Get_TypeParameterCount(MethodInfo methodInfo)
        {
            var output = methodInfo.GetGenericArguments().Length;
            return output;
        }

        /// <summary>
        /// Determines if the method has any input parameters.
        /// </summary>
        public bool Has_InputParameters(MethodInfo methodInfo)
        {
            var inputParameters = this.Get_InputParameters(methodInfo);

            var output = inputParameters.Any();
            return output;
        }

        /// <summary>
        /// Determines whether the method has any generic type parameters.
        /// </summary>
        public bool Is_Generic(MethodInfo methodInfo)
        {
            var output = methodInfo.IsGenericMethod;
            return output;
        }
    }
}
