using System;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IVersionOperator : IFunctionalityMarker
    {
        public string ToString_Default(Version version)
        {
            var output = version.ToString();
            return output;
        }
    }
}
