using System;
using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IMethodNameOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Determines if the method is an explicit, or implicit, conversion operator.
        /// </summary>
        public bool Is_ConversionOperator(string methodName)
        {
            var output = false
                || methodName == Instances.SpecialMethodNames.ImplicitConversionOperator
                || methodName == Instances.SpecialMethodNames.ExplicitConversionOperator;

            return output;
        }
    }
}
