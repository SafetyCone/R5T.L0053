using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using R5T.T0132;

using R5T.L0053.Extensions;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface ITypeInfoOperator : IFunctionalityMarker,
        L0066.ITypeInfoOperator
    {
        public string Get_NamespacedTypeName(TypeInfo typeInfo)
        {
            var output = Instances.TypeOperator.Get_NamespacedTypeName(typeInfo);
            return output;
        }
    }
}
