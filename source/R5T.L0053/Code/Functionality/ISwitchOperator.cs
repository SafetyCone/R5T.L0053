using System;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface ISwitchOperator : IFunctionalityMarker,
        L0066.ISwitchOperator
    {
        public ArgumentException Get_UnrecognizedSwitchTypeExpression<T>(T value)
        {
            var typeName = Instances.TypeOperator.Get_TypeNameOf(value);

            var exception = new ArgumentException($"{typeName} - Unrecognized type.");
            return exception;
        }
    }
}
