using System;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IParameterInfoOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Determines if the parameter is a C# "ref" parameter.
        /// This is determined by whether the type of the parameters is a by-reference type.
        /// </summary>
        public bool Is_Reference(ParameterInfo parameterInfo)
        {
            var output = parameterInfo.ParameterType.IsByRef;
            return output;
        }
    }
}
