using System;
using System.Linq;
using System.Reflection;

using R5T.N0000;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IMethodBaseOperator : IFunctionalityMarker,
        F10Y.L0000.IMethodBaseOperator,
        F10Y.L0001.L000.IMethodBaseOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IMethodBaseOperator _F10Y_L0000 => F10Y.L0000.MethodBaseOperator.Instance;

        [Ignore]
        public F10Y.L0001.L000.IMethodBaseOperator _F10Y_L0001_L000 => F10Y.L0001.L000.MethodBaseOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
