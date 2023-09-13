using System;
using System.Text;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IStringBuilderOperator : IFunctionalityMarker
    {
        public void Remove_Last(StringBuilder builder)
        {
            builder.Remove(builder.Length - 1, 1);
        }
    }
}
