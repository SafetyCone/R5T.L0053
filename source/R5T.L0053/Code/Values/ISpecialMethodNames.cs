using System;

using R5T.T0131;


namespace R5T.L0053
{
    [ValuesMarker]
    public partial interface ISpecialMethodNames : IValuesMarker
    {
        public string ImplicitConversionOperator => "op_Implicit";
        public string ExplicitConversionOperator => "op_Explicit";
    }
}
