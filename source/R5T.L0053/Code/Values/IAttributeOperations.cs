using System;
using System.Reflection;

using R5T.T0131;


namespace R5T.L0053
{
    [ValuesMarker]
    public partial interface IAttributeOperations : IValuesMarker
    {
        public Func<CustomAttributeData, bool> AttributeTypeNamespacedTypeName_Is(string attributeTypeNamespacedTypeName)
        {
            bool Internal(CustomAttributeData attribute)
            {
                var output = Instances.AttributeOperator.Is_TypeNamespacedTypeName(
                    attribute,
                    attributeTypeNamespacedTypeName);

                return output;
            }

            return Internal;
        }
    }
}
