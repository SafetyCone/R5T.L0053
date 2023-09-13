using System;

using R5T.T0132;


namespace R5T.L0053.Internal
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
        public string ExceptFirst_Unchecked(string @string)
        {
            var output = @string[1..];
            return output;
        }
    }
}
